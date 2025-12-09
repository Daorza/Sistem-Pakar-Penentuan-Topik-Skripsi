CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nama NVARCHAR(100) NOT NULL,
    nim NVARCHAR(20) NOT NULL,
    prodi NVARCHAR(100) NOT NULL,
    is_active BIT DEFAULT 1,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE topics (
    id INT IDENTITY(1,1) PRIMARY KEY,
    kode NVARCHAR(10) NOT NULL,
    nama NVARCHAR(100) NOT NULL,
    is_active BIT DEFAULT 1,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

INSERT INTO topics (kode, nama) VALUES
('ML', 'Machine Learning'),
('SD', 'Software Development'),
('NE', 'Network Engineer'),
('DS', 'Designer');

CREATE TABLE subtopics (
    id INT IDENTITY(1,1) PRIMARY KEY,
    topic_id INT NOT NULL,
    kode NVARCHAR(20) NOT NULL,
    nama NVARCHAR(150) NOT NULL,
    is_active BIT DEFAULT 1,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (topic_id) REFERENCES topics(id)
);

CREATE TABLE questions (
    id INT IDENTITY(1,1) PRIMARY KEY,
    pertanyaan NVARCHAR(MAX) NOT NULL,
    kategori NVARCHAR(20) CHECK (kategori IN ('TOPIK','METODE','REKOMENDASI','SUBTOPIK')),
    level INT NOT NULL,
    is_active BIT DEFAULT 1,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE question_rules (
    id INT IDENTITY(1,1) PRIMARY KEY,
    question_id INT NOT NULL,
    topic_id INT NULL,
    subtopic_id INT NULL,
    metode NVARCHAR(20) CHECK (metode IN ('KUALITATIF','KUANTITATIF')) NULL,
    rekomendasi NVARCHAR(20) CHECK (rekomendasi IN ('ANALISIS','MEMBUAT')) NULL,
    cf_pakar FLOAT DEFAULT 1,
    is_active BIT DEFAULT 1,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (question_id) REFERENCES questions(id),
    FOREIGN KEY (topic_id) REFERENCES topics(id),
    FOREIGN KEY (subtopic_id) REFERENCES subtopics(id)
);

CREATE TABLE user_answers (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    question_id INT NOT NULL,
    skala INT NOT NULL,
    cf_user FLOAT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (question_id) REFERENCES questions(id)
);

CREATE TABLE result_rankings (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    tipe NVARCHAR(20) CHECK (tipe IN ('TOPIK','SUBTOPIK')),
    ref_id INT NOT NULL,
    cf_value FLOAT NOT NULL,
    persentase INT NOT NULL,
    ranking INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE results (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    metode NVARCHAR(20) CHECK (metode IN ('KUALITATIF','KUANTITATIF')),
    rekomendasi NVARCHAR(20) CHECK (rekomendasi IN ('ANALISIS','MEMBUAT')),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(id)
);
