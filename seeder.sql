-- ================================================
-- COMPLETE DATA INSERT - Sistem Pakar Skripsi
-- Execute this FIRST before insert_questions.sql
-- ================================================

USE SistemPakarSkripsi;
GO

-- ================================================
-- 1. INSERT ADMIN USER
-- ================================================
IF NOT EXISTS (SELECT 1 FROM users WHERE nim = 'ADMIN001')
BEGIN
    INSERT INTO users (nama, nim, prodi, password, role) VALUES
    ('Administrator', 'ADMIN001', 'N/A', 'admin123', 'admin');
    PRINT 'Admin user created';
END
ELSE
BEGIN
    PRINT 'Admin user already exists';
END
GO

-- ================================================
-- 2. INSERT TOPICS (4 topics)
-- ================================================
IF NOT EXISTS (SELECT 1 FROM topics)
BEGIN
    INSERT INTO topics (kode, nama) VALUES
    ('ML', 'Machine Learning'),
    ('SOFTDEV', 'Software Development'),
    ('NETWORK', 'Network Engineer'),
    ('DESIGN', 'Designer');
    PRINT '4 Topics inserted';
END
ELSE
BEGIN
    PRINT 'Topics already exist';
END
GO

-- ================================================
-- 3. INSERT SUBTOPICS (20 subtopics)
-- ================================================
IF NOT EXISTS (SELECT 1 FROM subtopics)
BEGIN
    -- Machine Learning Subtopics (topic_id = 1)
    INSERT INTO subtopics (topic_id, kode, nama) VALUES
    (1, 'ML-CV', 'Computer Vision Engineer'),
    (1, 'ML-NLP', 'Natural Language Processing (NLP) Engineer'),
    (1, 'ML-DS', 'Data Scientist / Predictive Analytics'),
    (1, 'ML-OPS', 'MLOps / Model Deployment'),
    (1, 'ML-ES', 'Fuzzy / Experts System Specialist');

    -- Software Development Subtopics (topic_id = 2)
    INSERT INTO subtopics (topic_id, kode, nama) VALUES
    (2, 'SD-BE', 'Backend Engineering'),
    (2, 'SD-FS', 'Full-Stack Web Development'),
    (2, 'SD-MOB', 'Mobile App Development (Android/iOS)'),
    (2, 'SD-DB', 'Database Engineering / Data Modeling'),
    (2, 'SD-ARCH', 'Software Architecture / System Design');

    -- Network Engineer Subtopics (topic_id = 3)
    INSERT INTO subtopics (topic_id, kode, nama) VALUES
    (3, 'NET-RS', 'Routing & Switching'),
    (3, 'NET-SEC', 'Network Security'),
    (3, 'NET-SRV', 'Server & Infrastructure Management'),
    (3, 'NET-MON', 'Network Monitoring & Automation'),
    (3, 'NET-IOT', 'Wireless Networking & IoT Connectivity');

    -- Designer Subtopics (topic_id = 4)
    INSERT INTO subtopics (topic_id, kode, nama) VALUES
    (4, 'DES-UX', 'UI/UX Research & User Testing'),
    (4, 'DES-PROT', 'High Fidelity Prototyping (Figma)'),
    (4, 'DES-SYS', 'Design System & UI Components'),
    (4, 'DES-IXD', 'Interaction Design (IxD)'),
    (4, 'DES-PROD', 'Product Design (End-to-End)');
    
    PRINT '20 Subtopics inserted';
END
ELSE
BEGIN
    PRINT 'Subtopics already exist';
END
GO

-- ================================================
-- VERIFICATION
-- ================================================
SELECT 'Topics' AS TableName, COUNT(*) AS RecordCount FROM topics
UNION ALL
SELECT 'Subtopics', COUNT(*) FROM subtopics
UNION ALL
SELECT 'Users (Admin)', COUNT(*) FROM users WHERE role = 'admin';
GO

PRINT 'Master data inserted successfully!';
PRINT 'Now you can run insert_questions.sql';
GO
