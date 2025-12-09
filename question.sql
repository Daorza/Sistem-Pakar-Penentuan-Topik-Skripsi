-- ================================================
-- INSERT QUESTIONS & RULES - Sistem Pakar Skripsi
-- Total: 96 Pertanyaan (36 Level 1 + 60 Level 2)
-- ================================================

USE SistemPakarSkripsi;
GO

-- ================================================
-- LEVEL 1: TOPIK - Machine Learning (Q1-Q6)
-- ================================================
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik bekerja dengan dataset besar lalu mengolahnya menggunakan bahasa pemrograman seperti Python atau R untuk menemukan pola tertentu?', 'TOPIK', 1),
('Apakah kamu menikmati menjalankan proses komputasi berat dengan memanfaatkan GPU atau akselerator hardware lainnya agar proses selesai lebih cepat?', 'TOPIK', 1),
('Apakah kamu suka menulis script yang melakukan perhitungan berulang, lalu menyesuaikan parameter tertentu untuk mendapatkan hasil terbaik?', 'TOPIK', 1),
('Apakah kamu senang menggunakan software yang menampilkan grafik performa, log komputasi, atau visualisasi hasil eksperimen?', 'TOPIK', 1),
('Apakah kamu tertarik membuat sebuah sistem yang menerima input data dan menghasilkan output tertentu, lalu mengintegrasikannya ke aplikasi web atau mobile?', 'TOPIK', 1),
('Apakah kamu terbiasa menyiapkan environment teknis—seperti virtual environment, driver GPU, atau Docker—untuk menjalankan program yang membutuhkan resource besar?', 'TOPIK', 1);
GO

-- Question Rules: ML Questions → topic_id = 1 (Machine Learning)
INSERT INTO question_rules (question_id, topic_id, cf_pakar) VALUES
(1, 1, 1.0), (2, 1, 1.0), (3, 1, 1.0), (4, 1, 1.0), (5, 1, 1.0), (6, 1, 1.0);
GO

-- ================================================
-- LEVEL 1: TOPIK - Software Development (Q7-Q12)
-- ================================================
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik menyusun arsitektur aplikasi agar setiap modul dapat dikembangkan dan diuji secara terpisah?', 'TOPIK', 1),
('Apakah kamu menikmati proses debugging dengan menelusuri alur eksekusi untuk menemukan sumber error?', 'TOPIK', 1),
('Apakah kamu suka merancang struktur folder dan kode agar mudah diperluas tanpa mengganggu bagian lain dari sistem?', 'TOPIK', 1),
('Apakah kamu terbiasa membuat automation script seperti build tools, deployment script, atau workflow otomatis untuk menghindari pekerjaan manual berulang?', 'TOPIK', 1),
('Apakah kamu merasa puas ketika berhasil menulis fungsi atau kelas yang rapi, efisien, dan mudah dipahami programmer lain?', 'TOPIK', 1),
('Apakah kamu senang memecah satu fitur besar menjadi komponen kecil seperti service, helper, atau utility agar implementasinya lebih terkontrol?', 'TOPIK', 1);
GO

-- Question Rules: SW Dev Questions → topic_id = 2 (Software Development)
INSERT INTO question_rules (question_id, topic_id, cf_pakar) VALUES
(7, 2, 1.0), (8, 2, 1.0), (9, 2, 1.0), (10, 2, 1.0), (11, 2, 1.0), (12, 2, 1.0);
GO

-- ================================================
-- LEVEL 1: TOPIK - Network Engineer (Q13-Q18)
-- ================================================
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik mengonfigurasi perangkat seperti router, switch, dan firewall agar jaringan dapat berjalan stabil?', 'TOPIK', 1),
('Apakah kamu menikmati menganalisis paket data menggunakan tools seperti Wireshark untuk memahami alur komunikasi?', 'TOPIK', 1),
('Apakah kamu suka menelusuri penyebab gangguan jaringan, seperti latency tinggi, routing error, atau loop?', 'TOPIK', 1),
('Apakah kamu terbiasa memastikan keamanan jaringan dengan menerapkan VLAN, ACL, atau enkripsi pada jalur komunikasi?', 'TOPIK', 1),
('Apakah kamu senang mempelajari dan menerapkan protokol jaringan seperti TCP/IP, BGP, OSPF, atau DHCP?', 'TOPIK', 1),
('Apakah kamu merasa nyaman bertanggung jawab menjaga infrastruktur jaringan agar tetap online dan dapat digunakan sepanjang waktu?', 'TOPIK', 1);
GO

-- Question Rules: Network Questions → topic_id = 3 (Network Engineer)
INSERT INTO question_rules (question_id, topic_id, cf_pakar) VALUES
(13, 3, 1.0), (14, 3, 1.0), (15, 3, 1.0), (16, 3, 1.0), (17, 3, 1.0), (18, 3, 1.0);
GO

-- ================================================
-- LEVEL 1: TOPIK - UI/UX Designer (Q19-Q24)
-- ================================================
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik membuat wireframe atau prototype untuk menggambarkan alur penggunaan sebuah aplikasi?', 'TOPIK', 1),
('Apakah kamu menikmati melakukan usability testing untuk melihat apakah pengguna dapat menyelesaikan tugas tanpa kebingungan?', 'TOPIK', 1),
('Apakah kamu suka merancang antarmuka yang konsisten dengan design system seperti spacing, typography, dan komponen UI?', 'TOPIK', 1),
('Apakah kamu sering memikirkan bagaimana meminimalkan jumlah klik, geser, atau langkah agar pengalaman pengguna lebih efisien?', 'TOPIK', 1),
('Apakah kamu merasa puas ketika desainmu terlihat rapi, mudah dipahami, dan dapat diimplementasikan developer tanpa ambigu?', 'TOPIK', 1),
('Apakah kamu terbiasa menggunakan tools seperti Figma, Adobe XD, atau Sketch untuk membuat mockup dan prototype interaktif?', 'TOPIK', 1);
GO

-- Question Rules: Designer Questions → topic_id = 4 (Designer)
INSERT INTO question_rules (question_id, topic_id, cf_pakar) VALUES
(19, 4, 1.0), (20, 4, 1.0), (21, 4, 1.0), (22, 4, 1.0), (23, 4, 1.0), (24, 4, 1.0);
GO

-- ================================================
-- LEVEL 1: METODE - Kualitatif (Q25-Q27)
-- ================================================
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu lebih tertarik menggali alasan dan proses di balik sebuah fenomena daripada hanya mengetahui angka atau frekuensinya?', 'METODE', 1),
('Apakah kamu merasa nyaman bekerja dengan data seperti wawancara, cerita, atau observasi yang tidak berbentuk angka?', 'METODE', 1),
('Apakah kamu percaya bahwa pengalaman dan sudut pandang informan sangat penting untuk memahami inti sebuah masalah?', 'METODE', 1);
GO

-- Question Rules: Kualitatif → metode = 'KUALITATIF'
INSERT INTO question_rules (question_id, metode, cf_pakar) VALUES
(25, 'KUALITATIF', 1.0), (26, 'KUALITATIF', 1.0), (27, 'KUALITATIF', 1.0);
GO

-- ================================================
-- LEVEL 1: METODE - Kuantitatif (Q28-Q30)
-- ================================================
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu lebih yakin pada hasil penelitian yang didukung data statistik yang terukur dan dapat divalidasi?', 'METODE', 1),
('Apakah kamu menikmati menganalisis hubungan antar variabel menggunakan pendekatan matematis atau statistik?', 'METODE', 1),
('Apakah kamu lebih suka mengumpulkan data melalui instrumen standar seperti survei dengan pertanyaan terstruktur?', 'METODE', 1);
GO

-- Question Rules: Kuantitatif → metode = 'KUANTITATIF'
INSERT INTO question_rules (question_id, metode, cf_pakar) VALUES
(28, 'KUANTITATIF', 1.0), (29, 'KUANTITATIF', 1.0), (30, 'KUANTITATIF', 1.0);
GO

-- ================================================
-- LEVEL 1: REKOMENDASI - Membuat Produk (Q31-Q33)
-- ================================================
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu merasa paling puas ketika dapat menghasilkan produk atau aplikasi yang benar-benar bisa digunakan?', 'REKOMENDASI', 1),
('Apakah menurutmu sebuah penelitian baru dianggap selesai ketika ide tersebut sudah diwujudkan dalam bentuk prototipe yang berfungsi?', 'REKOMENDASI', 1),
('Apakah kamu lebih suka memecahkan masalah nyata dengan merancang solusi atau teknologi baru yang bisa langsung diterapkan?', 'REKOMENDASI', 1);
GO

-- Question Rules: Membuat → rekomendasi = 'MEMBUAT'
INSERT INTO question_rules (question_id, rekomendasi, cf_pakar) VALUES
(31, 'MEMBUAT', 1.0), (32, 'MEMBUAT', 1.0), (33, 'MEMBUAT', 1.0);
GO

-- ================================================
-- LEVEL 1: REKOMENDASI - Menganalisis (Q34-Q36)
-- ================================================
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu menikmati membongkar cara kerja sebuah sistem untuk menemukan kelemahan, celah keamanan, atau bagian yang tidak efisien?', 'REKOMENDASI', 1),
('Apakah kamu tertarik membandingkan performa beberapa metode atau teknik untuk menentukan mana yang paling efektif?', 'REKOMENDASI', 1),
('Apakah kamu merasa tertantang ketika harus mencari penyebab utama dari kegagalan atau kerusakan sebuah sistem?', 'REKOMENDASI', 1);
GO

-- Question Rules: Menganalisis → rekomendasi = 'ANALISIS'
INSERT INTO question_rules (question_id, rekomendasi, cf_pakar) VALUES
(34, 'ANALISIS', 1.0), (35, 'ANALISIS', 1.0), (36, 'ANALISIS', 1.0);
GO

-- ================================================
-- LEVEL 2: SUBTOPIK - Machine Learning
-- ================================================

-- Computer Vision (subtopic_id = 1)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik mengubah gambar menjadi representasi angka seperti matriks piksel untuk dianalisis dalam sebuah program?', 'SUBTOPIK', 2),
('Apakah kamu menikmati proses mendeteksi atau membedakan objek dalam sebuah gambar berdasarkan ciri visual seperti bentuk, warna, atau pola tekstur?', 'SUBTOPIK', 2),
('Apakah kamu suka menganalisis posisi atau pergerakan objek pada serangkaian gambar atau video untuk memahami perubahan yang terjadi dari waktu ke waktu?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(37, 1, 1.0), (38, 1, 1.0), (39, 1, 1.0);
GO

-- NLP (subtopic_id = 2)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik menganalisis struktur kalimat seperti subjek, predikat, dan konteks penggunaan kata untuk memahami makna yang lebih tepat?', 'SUBTOPIK', 2),
('Apakah kamu suka mengidentifikasi emosi, niat, atau informasi penting dari teks panjang lalu mengubahnya menjadi ringkasan yang lebih padat?', 'SUBTOPIK', 2),
('Apakah kamu ingin memahami bagaimana teks dapat diubah menjadi representasi numerik seperti embedding untuk mengukur kemiripan atau melakukan penerjemahan otomatis?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(40, 2, 1.0), (41, 2, 1.0), (42, 2, 1.0);
GO

-- Data Science (subtopic_id = 3)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik membangun model prediktif menggunakan algoritma seperti regression, decision tree, atau random forest untuk memecahkan masalah nyata?', 'SUBTOPIK', 2),
('Apakah kamu suka mengembangkan fitur (feature engineering) dari data mentah agar model dapat menghasilkan prediksi yang lebih akurat?', 'SUBTOPIK', 2),
('Apakah kamu menikmati proses menguji performa model menggunakan metrik seperti RMSE, accuracy, atau precision–recall untuk menentukan model terbaik?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(43, 3, 1.0), (44, 3, 1.0), (45, 3, 1.0);
GO

-- MLOps / Deployment Engineering (subtopic_id = 4)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik membangun sistem yang dapat menjalankan model secara stabil di production, lengkap dengan workflow otomatis untuk mengurangi kesalahan manual?', 'SUBTOPIK', 2),
('Apakah kamu suka membuat pipeline yang dapat memonitor performa model secara real-time, memberikan alert ketika kualitas menurun, dan tetap menangani trafik tinggi dengan konsisten?', 'SUBTOPIK', 2),
('Apakah kamu menikmati mengatur proses yang terstruktur seperti versioning, reproducibility, dan integrasi model ke dalam aplikasi atau layanan yang menggunakannya?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(46, 4, 1.0), (47, 4, 1.0), (48, 4, 1.0);
GO

-- Fuzzy / Expert System (subtopic_id = 5)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik bekerja dengan nilai yang tidak hanya "0 atau 1", dan merasa nyaman menangani data yang bersifat samar atau tidak pasti?', 'SUBTOPIK', 2),
('Apakah kamu menikmati proses mengambil pengetahuan dari pakar lalu mengubahnya menjadi aturan terstruktur seperti IF–THEN untuk digunakan sistem?', 'SUBTOPIK', 2),
('Apakah kamu suka membangun basis pengetahuan yang mampu memberikan alasan atau penjelasan ketika menghasilkan suatu keputusan?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(49, 5, 1.0), (50, 5, 1.0), (51, 5, 1.0);
GO

-- ================================================
-- LEVEL 2: SUBTOPIK - Software Development
-- ================================================

-- Backend Engineering (subtopic_id = 6)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik merancang alur logika di sisi server yang menentukan bagaimana data diproses dan bagaimana setiap komponen saling berinteraksi?', 'SUBTOPIK', 2),
('Apakah kamu menikmati membuat endpoint atau API yang rapi, terstruktur, aman, dan mampu menangani validasi serta sanitasi input dengan baik?', 'SUBTOPIK', 2),
('Apakah kamu suka mengoptimalkan waktu respons server sekaligus memastikan arsitektur backend tetap stabil dan mampu menangani peningkatan beban pengguna?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(52, 6, 1.0), (53, 6, 1.0), (54, 6, 1.0);
GO

-- Fullstack Web Development (subtopic_id = 7)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik memahami alur lengkap sebuah aplikasi web, mulai dari bagaimana data disimpan di database hingga bagaimana hasilnya ditampilkan di browser?', 'SUBTOPIK', 2),
('Apakah kamu menikmati membangun fitur secara menyeluruh, termasuk membuat tampilan frontend dan menghubungkannya dengan proses backend agar aplikasi dapat berjalan end-to-end?', 'SUBTOPIK', 2),
('Apakah kamu suka menelusuri dan memperbaiki masalah baik di sisi klien maupun server sambil menjaga agar aplikasi tetap cepat, responsif, dan nyaman digunakan?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(55, 7, 1.0), (56, 7, 1.0), (57, 7, 1.0);
GO

-- Mobile App Development (subtopic_id = 8)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik merancang antarmuka yang tetap nyaman dan mudah digunakan pada layar kecil, termasuk mengatur navigasi dan gesture seperti tap atau swipe?', 'SUBTOPIK', 2),
('Apakah kamu menikmati mengembangkan fitur yang memanfaatkan sensor perangkat seperti GPS, kamera, atau accelerometer sambil memastikan aplikasi tetap berjalan stabil dalam kondisi jaringan yang tidak menentu?', 'SUBTOPIK', 2),
('Apakah kamu suka mengoptimalkan performa aplikasi agar hemat daya, responsif, dan memberikan umpan balik seperti animasi halus atau getaran ringan saat pengguna berinteraksi?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(58, 8, 1.0), (59, 8, 1.0), (60, 8, 1.0);
GO

-- Database Engineering (subtopic_id = 9)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik merancang struktur tabel dan relasi yang teratur sehingga data tersimpan efisien dan mudah digunakan tanpa duplikasi yang tidak perlu?', 'SUBTOPIK', 2),
('Apakah kamu menikmati membuat query yang cepat dan stabil sambil memastikan data tetap konsisten melalui prinsip seperti transaksi dan komit yang aman?', 'SUBTOPIK', 2),
('Apakah kamu suka mengelola banyak transaksi yang berjalan bersamaan, mencegah konflik data, serta menyiapkan mekanisme backup dan recovery agar sistem tetap aman?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(61, 9, 1.0), (62, 9, 1.0), (63, 9, 1.0);
GO

-- Software Architecture / System Design (subtopic_id = 10)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik merancang bagaimana berbagai komponen seperti service, database, cache, dan queue saling berkomunikasi agar sistem bekerja dengan efisien?', 'SUBTOPIK', 2),
('Apakah kamu menikmati memikirkan cara membangun sistem yang mampu menangani lonjakan trafik dengan tetap menjaga performa melalui teknik seperti load balancing atau horizontal scaling?', 'SUBTOPIK', 2),
('Apakah kamu suka mempertimbangkan trade-off antar pilihan desain, seperti konsistensi vs ketersediaan, atau monolith vs microservices, saat merancang arsitektur aplikasi?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(64, 10, 1.0), (65, 10, 1.0), (66, 10, 1.0);
GO

-- ================================================
-- LEVEL 2: SUBTOPIK - Network Engineer
-- ================================================

-- Routing & Switching (subtopic_id = 11)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik mengonfigurasi router dan switch untuk menentukan jalur terbaik bagi data agar dapat mencapai tujuan dengan cepat dan stabil?', 'SUBTOPIK', 2),
('Apakah kamu menikmati menganalisis masalah jaringan seperti loop, collision domain, atau routing error menggunakan tools atau command-line perangkat jaringan?', 'SUBTOPIK', 2),
('Apakah kamu suka merancang topologi jaringan yang efisien dengan memanfaatkan VLAN, trunking, routing protokol, dan segmentasi untuk meningkatkan keamanan serta performa jaringan?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(67, 11, 1.0), (68, 11, 1.0), (69, 11, 1.0);
GO

-- Network Security (subtopic_id = 12)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik mengamankan jaringan dengan menerapkan konfigurasi firewall, filtering, dan akses berbasis aturan untuk mencegah akses yang tidak sah?', 'SUBTOPIK', 2),
('Apakah kamu menikmati menganalisis lalu lintas jaringan untuk mendeteksi pola mencurigakan seperti scanning, brute force, atau anomali lainnya?', 'SUBTOPIK', 2),
('Apakah kamu suka merancang strategi pertahanan berlapis seperti segmentasi jaringan, enkripsi, dan sistem deteksi intrusi untuk menjaga integritas dan kerahasiaan data?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(70, 12, 1.0), (71, 12, 1.0), (72, 12, 1.0);
GO

-- Server & Infrastructure Management (subtopic_id = 13)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik mengelola server dan sistem operasi, termasuk mengatur layanan, permission, serta memastikan lingkungan tetap stabil dan aman?', 'SUBTOPIK', 2),
('Apakah kamu menikmati memantau performa server seperti CPU, RAM, storage, dan network, lalu melakukan tuning agar sistem tetap responsif di bawah beban tinggi?', 'SUBTOPIK', 2),
('Apakah kamu suka menyiapkan infrastruktur seperti load balancer, backup otomatis, dan mekanisme high availability untuk memastikan layanan tetap berjalan tanpa downtime?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(73, 13, 1.0), (74, 13, 1.0), (75, 13, 1.0);
GO

-- Network Monitoring & Automation (subtopic_id = 14)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik memantau kesehatan jaringan menggunakan tools seperti SNMP, NetFlow, atau dashboard monitoring untuk mendeteksi masalah sebelum mengganggu pengguna?', 'SUBTOPIK', 2),
('Apakah kamu menikmati membuat otomatisasi konfigurasi atau task jaringan menggunakan script atau framework seperti Ansible, Python, atau API perangkat jaringan?', 'SUBTOPIK', 2),
('Apakah kamu suka menganalisis log dan metrik jaringan secara berkala lalu membuat rule otomatis untuk menangani anomali atau melakukan perbaikan tanpa intervensi manual?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(76, 14, 1.0), (77, 14, 1.0), (78, 14, 1.0);
GO

-- Wireless Networking & IoT Connectivity (subtopic_id = 15)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik mengonfigurasi jaringan nirkabel agar stabil dan memiliki jangkauan optimal, termasuk mengatur kanal, frekuensi, dan keamanan Wi-Fi?', 'SUBTOPIK', 2),
('Apakah kamu menikmati menghubungkan perangkat IoT ke jaringan, memastikan setiap perangkat dapat berkomunikasi menggunakan protokol seperti MQTT, CoAP, atau BLE?', 'SUBTOPIK', 2),
('Apakah kamu suka menganalisis interferensi, kekuatan sinyal, dan penggunaan spektrum untuk menjaga koneksi tetap andal terutama pada lingkungan dengan banyak perangkat?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(79, 15, 1.0), (80, 15, 1.0), (81, 15, 1.0);
GO

-- ================================================
-- LEVEL 2: SUBTOPIK - Designer
-- ================================================

-- UX Research & User Testing (subtopic_id = 16)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu menikmati menggali kebutuhan dan perilaku pengguna melalui wawancara, observasi, atau usability testing untuk memahami motivasi serta hambatan mereka?', 'SUBTOPIK', 2),
('Apakah kamu tertarik menganalisis pola perilaku pengguna dan menghubungkannya dengan prinsip psikologi seperti beban kognitif, persepsi, atau pengambilan keputusan?', 'SUBTOPIK', 2),
('Apakah kamu suka menyusun temuan penelitian menjadi insight yang dapat digunakan untuk memperbaiki alur, fitur, atau desain produk agar lebih ramah pengguna?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(82, 16, 1.0), (83, 16, 1.0), (84, 16, 1.0);
GO

-- High-Fidelity Prototyping (subtopic_id = 17)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu menikmati membuat prototype dengan detail visual yang mendekati produk akhir, lengkap dengan layout, warna, dan gaya komponen yang konsisten?', 'SUBTOPIK', 2),
('Apakah kamu suka merancang interaksi yang realistis seperti animasi, transition, hover state, dan gesture agar prototype terasa seperti aplikasi yang sebenarnya?', 'SUBTOPIK', 2),
('Apakah kamu tertarik menggunakan tools seperti Figma, Adobe XD, atau ProtoPie untuk membuat alur pengguna yang dapat diuji langsung tanpa perlu coding?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(85, 17, 1.0), (86, 17, 1.0), (87, 17, 1.0);
GO

-- Design Systems & UI Components (subtopic_id = 18)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik menyusun aturan desain seperti warna, tipografi, grid, spacing, dan ikonografi agar seluruh tampilan aplikasi terlihat konsisten?', 'SUBTOPIK', 2),
('Apakah kamu menikmati membuat atau mengelola komponen UI seperti button, card, modal, atau form field sehingga dapat digunakan kembali di berbagai halaman aplikasi?', 'SUBTOPIK', 2),
('Apakah kamu suka memastikan dokumentasi dan guideline desain selalu terbarui agar tim desain dan developer dapat mengikuti standar visual yang sama?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(88, 18, 1.0), (89, 18, 1.0), (90, 18, 1.0);
GO

-- Interaction Design (subtopic_id = 19)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik merancang bagaimana pengguna berinteraksi dengan elemen di layar, seperti bagaimana tombol bereaksi, bagaimana navigasi bekerja, atau bagaimana sistem memberikan respons terhadap tindakan pengguna?', 'SUBTOPIK', 2),
('Apakah kamu menikmati menciptakan alur interaksi yang jelas dan natural, memastikan setiap langkah terasa logis dan tidak menimbulkan kebingungan bagi pengguna?', 'SUBTOPIK', 2),
('Apakah kamu suka merancang feedback seperti animasi, perubahan warna, atau micro-interactions untuk membantu pengguna memahami apa yang sedang terjadi di aplikasi?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(91, 19, 1.0), (92, 19, 1.0), (93, 19, 1.0);
GO

-- Product Design (End-to-End) (subtopic_id = 20)
INSERT INTO questions (pertanyaan, kategori, level) VALUES
('Apakah kamu tertarik memahami seluruh perjalanan pengguna dari awal hingga akhir, lalu merancang solusi yang mencakup riset, ideasi, prototyping, hingga validasi?', 'SUBTOPIK', 2),
('Apakah kamu menikmati menyusun alur produk yang menghubungkan fitur-fitur kunci dengan masalah pengguna sehingga hasil akhirnya bukan hanya terlihat bagus, tetapi juga benar-benar memecahkan kebutuhan mereka?', 'SUBTOPIK', 2),
('Apakah kamu suka menggabungkan perspektif bisnis, teknologi, dan desain untuk menghasilkan produk yang layak secara teknis, bermanfaat bagi pengguna, dan bernilai bagi perusahaan?', 'SUBTOPIK', 2);
GO
INSERT INTO question_rules (question_id, subtopic_id, cf_pakar) VALUES
(94, 20, 1.0), (95, 20, 1.0), (96, 20, 1.0);
GO

-- ================================================
-- VERIFICATION
-- ================================================
PRINT 'Total Questions inserted: ' + CAST((SELECT COUNT(*) FROM questions) AS NVARCHAR(10));
PRINT 'Total Question Rules inserted: ' + CAST((SELECT COUNT(*) FROM question_rules) AS NVARCHAR(10));

SELECT 'Level 1 - TOPIK' AS Category, COUNT(*) AS Total FROM questions WHERE level = 1 AND kategori = 'TOPIK'
UNION ALL
SELECT 'Level 1 - METODE', COUNT(*) FROM questions WHERE level = 1 AND kategori = 'METODE'
UNION ALL
SELECT 'Level 1 - REKOMENDASI', COUNT(*) FROM questions WHERE level = 1 AND kategori = 'REKOMENDASI'
UNION ALL
SELECT 'Level 2 - SUBTOPIK', COUNT(*) FROM questions WHERE level = 2 AND kategori = 'SUBTOPIK';

PRINT 'Questions inserted successfully!';
GO
