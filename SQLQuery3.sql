USE [SistemPakarSkripsi];
GO

-- Pastikan topics sudah ada (id bisa 1..4 sesuai insert awal)
-- ML=1, SD=2, NE=3, DS=4 (kalau urutannya sesuai)

DECLARE 
    @Q1 INT, @Q2 INT, @Q3 INT, @Q4 INT, @Q5 INT, @Q6 INT,
    @Q7 INT, @Q8 INT, @Q9 INT, @Q10 INT, @Q11 INT, @Q12 INT,
    @Q13 INT, @Q14 INT, @Q15 INT, @Q16 INT, @Q17 INT, @Q18 INT,
    @Q19 INT, @Q20 INT, @Q21 INT, @Q22 INT, @Q23 INT, @Q24 INT,
    @Q25 INT, @Q26 INT, @Q27 INT,
    @Q28 INT, @Q29 INT, @Q30 INT,
    @Q31 INT, @Q32 INT, @Q33 INT,
    @Q34 INT, @Q35 INT, @Q36 INT;

------------------------------
-- TOPIK: MACHINE LEARNING
------------------------------
INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu tertarik bekerja dengan dataset besar lalu mengolahnya menggunakan bahasa pemrograman seperti Python atau R untuk menemukan pola tertentu?', 'TOPIK', 1);
SET @Q1 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu menikmati menjalankan proses komputasi berat dengan memanfaatkan GPU atau akselerator hardware lainnya agar proses selesai lebih cepat?', 'TOPIK', 1);
SET @Q2 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu suka menulis script yang melakukan perhitungan berulang, lalu menyesuaikan parameter tertentu untuk mendapatkan hasil terbaik?', 'TOPIK', 1);
SET @Q3 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu senang menggunakan software yang menampilkan grafik performa, log komputasi, atau visualisasi hasil eksperimen?', 'TOPIK', 1);
SET @Q4 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu tertarik membuat sebuah sistem yang menerima input data dan menghasilkan output tertentu, lalu mengintegrasikannya ke aplikasi web atau mobile?', 'TOPIK', 1);
SET @Q5 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu terbiasa menyiapkan environment teknis—seperti virtual environment, driver GPU, atau Docker—untuk menjalankan program yang membutuhkan resource besar?', 'TOPIK', 1);
SET @Q6 = SCOPE_IDENTITY();

------------------------------
-- TOPIK: SOFTWARE DEVELOPMENT
------------------------------
INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu tertarik menyusun arsitektur aplikasi agar setiap modul dapat dikembangkan dan diuji secara terpisah?', 'TOPIK', 1);
SET @Q7 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu menikmati proses debugging dengan menelusuri alur eksekusi untuk menemukan sumber error?', 'TOPIK', 1);
SET @Q8 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu suka merancang struktur folder dan kode agar mudah diperluas tanpa mengganggu bagian lain dari sistem?', 'TOPIK', 1);
SET @Q9 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu terbiasa membuat automation script seperti build tools, deployment script, atau workflow otomatis untuk menghindari pekerjaan manual berulang?', 'TOPIK', 1);
SET @Q10 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu merasa puas ketika berhasil menulis fungsi atau kelas yang rapi, efisien, dan mudah dipahami programmer lain?', 'TOPIK', 1);
SET @Q11 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu senang memecah satu fitur besar menjadi komponen kecil seperti service, helper, atau utility agar implementasinya lebih terkontrol?', 'TOPIK', 1);
SET @Q12 = SCOPE_IDENTITY();

------------------------------
-- TOPIK: NETWORK ENGINEER
------------------------------
INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu tertarik mengonfigurasi perangkat seperti router, switch, dan firewall agar jaringan dapat berjalan stabil?', 'TOPIK', 1);
SET @Q13 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu menikmati menganalisis paket data menggunakan tools seperti Wireshark untuk memahami alur komunikasi?', 'TOPIK', 1);
SET @Q14 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu suka menelusuri penyebab gangguan jaringan, seperti latency tinggi, routing error, atau loop?', 'TOPIK', 1);
SET @Q15 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu terbiasa memastikan keamanan jaringan dengan menerapkan VLAN, ACL, atau enkripsi pada jalur komunikasi?', 'TOPIK', 1);
SET @Q16 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu senang mempelajari dan menerapkan protokol jaringan seperti TCP/IP, BGP, OSPF, atau DHCP?', 'TOPIK', 1);
SET @Q17 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu merasa nyaman bertanggung jawab menjaga infrastruktur jaringan agar tetap online dan dapat digunakan sepanjang waktu?', 'TOPIK', 1);
SET @Q18 = SCOPE_IDENTITY();

------------------------------
-- TOPIK: UI/UX DESIGNER
------------------------------
INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu tertarik membuat wireframe atau prototype untuk menggambarkan alur penggunaan sebuah aplikasi?', 'TOPIK', 1);
SET @Q19 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu menikmati melakukan usability testing untuk melihat apakah pengguna dapat menyelesaikan tugas tanpa kebingungan?', 'TOPIK', 1);
SET @Q20 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu suka merancang antarmuka yang konsisten dengan design system seperti spacing, typography, dan komponen UI?', 'TOPIK', 1);
SET @Q21 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu sering memikirkan bagaimana meminimalkan jumlah klik, geser, atau langkah agar pengalaman pengguna lebih efisien?', 'TOPIK', 1);
SET @Q22 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu merasa puas ketika desainmu terlihat rapi, mudah dipahami, dan dapat diimplementasikan developer tanpa ambigu?', 'TOPIK', 1);
SET @Q23 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu terbiasa menggunakan tools seperti Figma, Adobe XD, atau Sketch untuk membuat mockup dan prototype interaktif?', 'TOPIK', 1);
SET @Q24 = SCOPE_IDENTITY();

------------------------------
-- METODE: KUALITATIF
------------------------------
INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu lebih tertarik menggali alasan dan proses di balik sebuah fenomena daripada hanya mengetahui angka atau frekuensinya?', 'METODE', 1);
SET @Q25 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu merasa nyaman bekerja dengan data seperti wawancara, cerita, atau observasi yang tidak berbentuk angka?', 'METODE', 1);
SET @Q26 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu percaya bahwa pengalaman dan sudut pandang informan sangat penting untuk memahami inti sebuah masalah?', 'METODE', 1);
SET @Q27 = SCOPE_IDENTITY();

------------------------------
-- METODE: KUANTITATIF
------------------------------
INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu lebih yakin pada hasil penelitian yang didukung data statistik yang terukur dan dapat divalidasi?', 'METODE', 1);
SET @Q28 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu menikmati menganalisis hubungan antar variabel menggunakan pendekatan matematis atau statistik?', 'METODE', 1);
SET @Q29 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu lebih suka mengumpulkan data melalui instrumen standar seperti survei dengan pertanyaan terstruktur?', 'METODE', 1);
SET @Q30 = SCOPE_IDENTITY();

------------------------------
-- REKOMENDASI: MEMBUAT PRODUK (R&D)
------------------------------
INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu merasa paling puas ketika dapat menghasilkan produk atau aplikasi yang benar-benar bisa digunakan?', 'REKOMENDASI', 1);
SET @Q31 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Menurutmu sebuah penelitian baru dianggap selesai ketika ide tersebut sudah diwujudkan dalam bentuk prototipe yang berfungsi?', 'REKOMENDASI', 1);
SET @Q32 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu lebih suka memecahkan masalah nyata dengan merancang solusi atau teknologi baru yang bisa langsung diterapkan?', 'REKOMENDASI', 1);
SET @Q33 = SCOPE_IDENTITY();

------------------------------
-- REKOMENDASI: MENGANALISIS PRODUK
------------------------------
INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu menikmati membongkar cara kerja sebuah sistem untuk menemukan kelemahan, celah keamanan, atau bagian yang tidak efisien?', 'REKOMENDASI', 1);
SET @Q34 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu tertarik membandingkan performa beberapa metode atau teknik untuk menentukan mana yang paling efektif?', 'REKOMENDASI', 1);
SET @Q35 = SCOPE_IDENTITY();

INSERT INTO questions (pertanyaan, kategori, level)
VALUES (N'Apakah kamu merasa tertantang ketika harus mencari penyebab utama dari kegagalan atau kerusakan sebuah sistem?', 'REKOMENDASI', 1);
SET @Q36 = SCOPE_IDENTITY();

---------------------------------
-- RULE BASE (question_rules)
---------------------------------
-- Asumsi: topics
-- 1 = ML, 2 = SD, 3 = NE, 4 = Designer

-- Machine Learning (Q1–Q6)
INSERT INTO question_rules (question_id, topic_id, cf_pakar) VALUES
(@Q1, 1, 1),
(@Q2, 1, 1),
(@Q3, 1, 1),
(@Q4, 1, 1),
(@Q5, 1, 1),
(@Q6, 1, 1);

-- Software Development (Q7–Q12)
INSERT INTO question_rules (question_id, topic_id, cf_pakar) VALUES
(@Q7, 2, 1),
(@Q8, 2, 1),
(@Q9, 2, 1),
(@Q10, 2, 1),
(@Q11, 2, 1),
(@Q12, 2, 1);

-- Network Engineer (Q13–Q18)
INSERT INTO question_rules (question_id, topic_id, cf_pakar) VALUES
(@Q13, 3, 1),
(@Q14, 3, 1),
(@Q15, 3, 1),
(@Q16, 3, 1),
(@Q17, 3, 1),
(@Q18, 3, 1);

-- UI/UX Designer (Q19–Q24)
INSERT INTO question_rules (question_id, topic_id, cf_pakar) VALUES
(@Q19, 4, 1),
(@Q20, 4, 1),
(@Q21, 4, 1),
(@Q22, 4, 1),
(@Q23, 4, 1),
(@Q24, 4, 1);

-- Metode KUALITATIF (Q25–Q27)
INSERT INTO question_rules (question_id, metode, cf_pakar) VALUES
(@Q25, 'KUALITATIF', 1),
(@Q26, 'KUALITATIF', 1),
(@Q27, 'KUALITATIF', 1);

-- Metode KUANTITATIF (Q28–Q30)
INSERT INTO question_rules (question_id, metode, cf_pakar) VALUES
(@Q28, 'KUANTITATIF', 1),
(@Q29, 'KUANTITATIF', 1),
(@Q30, 'KUANTITATIF', 1);

-- Rekomendasi MEMBUAT (Q31–Q33)
INSERT INTO question_rules (question_id, rekomendasi, cf_pakar) VALUES
(@Q31, 'MEMBUAT', 1),
(@Q32, 'MEMBUAT', 1),
(@Q33, 'MEMBUAT', 1);

-- Rekomendasi ANALISIS (Q34–Q36)
INSERT INTO question_rules (question_id, rekomendasi, cf_pakar) VALUES
(@Q34, 'ANALISIS', 1),
(@Q35, 'ANALISIS', 1),
(@Q36, 'ANALISIS', 1);
GO
