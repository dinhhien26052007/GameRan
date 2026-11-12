using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SnakeGame
{
    // ============================================================
    //  GAME CON RẮN (SNAKE) — WinForms
    //  Điều khiển:  Mũi tên / WASD  —  SPACE: bắt đầu / tạm dừng / chơi lại
    // ============================================================
    public class GameForm : Form
    {
        // ================== CẤU HÌNH ==================
        const int SoO = 20;     // bàn cờ gồm SoO x SoO ô
        const int CoO = 24;     // kích thước 1 ô (pixel)
        const int LeTren = 60;  // chừa chỗ trên cùng để vẽ điểm số

        // ================== TRẠNG THÁI GAME ==================
        readonly System.Windows.Forms.Timer timer = new();  // "trái tim": chạy lại liên tục
        readonly List<Point> ran = new();   // thân rắn — phần tử [0] là ĐẦU
        Point huong;                        // hướng đang đi
        Point huongCho;                     // hướng vừa bấm (áp dụng ở bước kế tiếp)
        Point thucAn;                       // vị trí thức ăn
        readonly Random rd = new();
        int diem;
        int diemCaoNhat;                    // kỷ lục trong phiên chơi này
        bool choi;                          // đang chơi?
        bool tamDung;
        bool ketThuc;                       // vừa thua?

        public GameForm()
        {
            Text = "Game Con Rắn - Snake";
            ClientSize = new Size(SoO * CoO, SoO * CoO + LeTren);
            BackColor = Color.FromArgb(28, 28, 38);
            FormBorderStyle = FormBorderStyle.FixedSingle;  // không cho kéo giãn cửa sổ
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;                          // chống nhấp nháy khi vẽ
            KeyPreview = true;

            KeyDown += GameForm_KeyDown;
            Paint += GameForm_Paint;

            timer.Interval = 150;   // rắn bò 1 bước mỗi 150 mili-giây
            timer.Tick += (s, e) => DiMotBuoc();

            BatDauLai();
        }

        // ================== ĐIỀU KHIỂN ==================
        void GameForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (!choi)
                    BatDau();
                else
                {
                    tamDung = !tamDung;                 // đang chơi → tạm dừng / tiếp tục
                    if (tamDung) timer.Stop(); else timer.Start();
                    Invalidate();
                }
                return;
            }

            if (!choi || tamDung) return;

            // Đổi hướng — cấm quay ngược 180 độ (đâm vào cổ mình)
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && huong != new Point(1, 0)) huongCho = new Point(-1, 0);
            if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && huong != new Point(-1, 0)) huongCho = new Point(1, 0);
            if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W) && huong != new Point(0, 1)) huongCho = new Point(0, -1);
            if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.S) && huong != new Point(0, -1)) huongCho = new Point(0, 1);
        }

        void BatDau()
        {
            BatDauLai();
            choi = true;
            timer.Start();
            Invalidate();
        }

        // Reset toàn bộ về trạng thái ban đầu
        void BatDauLai()
        {
            ran.Clear();
            int giua = SoO / 2;
            for (int i = 0; i < 4; i++)
                ran.Add(new Point(giua - i, giua));     // 4 đốt nằm ngang giữa bàn cờ

            huong = huongCho = new Point(1, 0);         // xuất phát đi sang phải
            diem = 0;
            ketThuc = false;
            tamDung = false;
            timer.Interval = 150;
            DatThucAn();
            Invalidate();
        }

        // ================== LUẬT CHƠI ==================
        void DiMotBuoc()
        {
            huong = huongCho;
            Point dau = ran[0] + new Size(huong.X, huong.Y);   // vị trí đầu mới
            bool anDuoc = dau == thucAn;

            // Đâm tường?
            if (dau.X < 0 || dau.Y < 0 || dau.X >= SoO || dau.Y >= SoO)
            {
                Thua();
                return;
            }

            // Cắn vào thân? (bỏ qua đốt đuôi vì nó sắp rời đi — trừ khi đang ăn để dài ra)
            int soCanKiemTra = ran.Count - (anDuoc ? 0 : 1);
            for (int i = 0; i < soCanKiemTra; i++)
            {
                if (ran[i] == dau)
                {
                    Thua();
                    return;
                }
            }

            ran.Insert(0, dau);                 // đầu mới tiến lên 1 ô

            if (anDuoc)
            {
                diem++;                         // ăn được → KHÔNG bỏ đốt đuôi => rắn dài ra
                if (diem > diemCaoNhat) diemCaoNhat = diem;

                timer.Interval = Math.Max(70, timer.Interval - 3);  // càng ăn càng nhanh
                DatThucAn();
            }
            else
            {
                ran.RemoveAt(ran.Count - 1);    // không ăn → đuôi rụng đi 1 đốt
            }

            Invalidate();                       // yêu cầu vẽ lại toàn bộ
        }

        void Thua()
        {
            choi = false;
            ketThuc = true;
            timer.Stop();
            Invalidate();
        }

        // Đặt thức ăn ở ô ngẫu nhiên, không đè lên người rắn
        void DatThucAn()
        {
            Point p;
            do
            {
                p = new Point(rd.Next(SoO), rd.Next(SoO));
            } while (ran.Contains(p));
            thucAn = p;
        }

        // ================== VẼ GIAO DIỆN ==================
        void GameForm_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            VeBanCo(g);
            VeThucAn(g);
            VeRan(g);
            VeHud(g);
        }

        void VeBanCo(Graphics g)
        {
            var khung = new Rectangle(0, LeTren, SoO * CoO, SoO * CoO);
            using var brush = new SolidBrush(Color.FromArgb(40, 40, 55));
            g.FillRectangle(brush, khung);

            // Lưới mờ
            using var pen = new Pen(Color.FromArgb(55, 55, 75));
            for (int i = 1; i < SoO; i++)
            {
                g.DrawLine(pen, i * CoO, LeTren, i * CoO, LeTren + SoO * CoO);
                g.DrawLine(pen, 0, LeTren + i * CoO, SoO * CoO, LeTren + i * CoO);
            }
        }

        void VeThucAn(Graphics g)
        {
            float r = CoO / 2f - 4;
            float x = thucAn.X * CoO + CoO / 2f - r;
            float y = LeTren + thucAn.Y * CoO + CoO / 2f - r;

            using var brush = new SolidBrush(Color.FromArgb(255, 90, 60));
            g.FillEllipse(brush, x, y, r * 2, r * 2);

            using var pen = new Pen(Color.FromArgb(255, 140, 120), 2f);
            g.DrawEllipse(pen, x, y, r * 2, r * 2);
        }

        void VeRan(Graphics g)
        {
            // Thân: vẽ từ đuôi lên, màu càng xa đầu càng nhạt
            for (int i = ran.Count - 1; i >= 1; i--)
            {
                using var brush = new SolidBrush(MauThan(i));
                g.FillRectangle(brush, ran[i].X * CoO + 2, LeTren + ran[i].Y * CoO + 2, CoO - 4, CoO - 4);
            }

            // Đầu: vẽ sau cùng để nằm trên thân, kèm 2 mắt nhìn theo hướng đi
            Point dau = ran[0];
            using (var brush = new SolidBrush(Color.FromArgb(120, 255, 120)))
                g.FillRectangle(brush, dau.X * CoO + 1, LeTren + dau.Y * CoO + 1, CoO - 2, CoO - 2);

            float cx = dau.X * CoO + CoO / 2f;
            float cy = LeTren + dau.Y * CoO + CoO / 2f;
            float px = -huong.Y, py = huong.X;   // vector vuông góc với hướng đi
            float r = CoO / 9f;

            for (int mat = -1; mat <= 1; mat += 2)
            {
                float mx = cx + huong.X * CoO / 6f + px * CoO / 5f * mat;
                float my = cy + huong.Y * CoO / 6f + py * CoO / 5f * mat;
                g.FillEllipse(Brushes.White, mx - r, my - r, r * 2, r * 2);
            }
        }

        // Màu thân rắn: chuyển dần từ xanh lá đậm (đầu) sang xanh nhạt (đuôi)
        Color MauThan(int i)
        {
            double t = (double)i / Math.Max(1, ran.Count - 1);   // 0 = gần đầu, 1 = đuôi
            return Color.FromArgb(
                (int)(120 - 60 * t),
                (int)(230 - 110 * t),
                (int)(120 - 60 * t));
        }

        void VeHud(Graphics g)
        {
            using var font = new Font("Segoe UI", 13, FontStyle.Bold);
            using var brush = new SolidBrush(Color.White);
            g.DrawString($"Điểm: {diem}", font, brush, 10, 15);
            g.DrawString($"Kỷ lục: {diemCaoNhat}", font, brush, 140, 15);

            string? thongBao = null;
            if (ketThuc) thongBao = $"GAME OVER!  Điểm: {diem}\nNhấn SPACE để chơi lại";
            else if (tamDung) thongBao = "TẠM DỪNG - nhấn SPACE để tiếp tục";
            else if (!choi) thongBao = "Nhấn SPACE để bắt đầu!\n(Điều khiển: mũi tên / WASD)";

            if (thongBao != null)
            {
                var vung = new RectangleF(0, LeTren + SoO * CoO / 2f - 50, SoO * CoO, 100);
                using var nen = new SolidBrush(Color.FromArgb(170, 0, 0, 0));
                g.FillRectangle(nen, vung);

                using var fontTo = new Font("Segoe UI", 15, FontStyle.Bold);
                var canGiua = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(thongBao, fontTo, Brushes.White, vung, canGiua);
            }
        }
    }
}
