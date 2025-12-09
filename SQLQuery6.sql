INSERT INTO questions (pertanyaan,kategori,level) VALUES
('Apakah kamu tertarik mengubah gambar menjadi representasi angka seperti matriks piksel untuk dianalisis dalam sebuah program?','SUBTOPIK',3),
('Apakah kamu menikmati proses mendeteksi atau membedakan objek dalam sebuah gambar berdasarkan ciri visual seperti bentuk, warna, atau pola tekstur?','SUBTOPIK',3),
('Apakah kamu suka menganalisis posisi atau pergerakan objek pada serangkaian gambar atau video untuk memahami perubahan yang terjadi dari waktu ke waktu?','SUBTOPIK',3);

INSERT INTO question_rules (question_id,topic_id,subtopic_id,cf_pakar) VALUES
(1,1,1,1),(2,1,1,1),(3,1,1,1);