CREATE TABLE [dbo].[subtopics] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [topic_id]   INT            NOT NULL,
    [kode]       NVARCHAR (20)  NOT NULL,
    [nama]       NVARCHAR (150) NOT NULL,
    [is_active]  BIT            DEFAULT ((1)) NULL,
    [created_at] DATETIME       DEFAULT (getdate()) NULL,
    [updated_at] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([topic_id]) REFERENCES [dbo].[topics] ([id])
);

INSERT INTO subtopics (topic_id, kode, nama) VALUES
(1, 'CV',  'Computer Vision'),
(1, 'NLP', 'Natural Language Processing'),
(1, 'DS',  'Data Science'),
(1, 'MLOPS','Deployment Engineering'),
(1, 'ES',  'Fuzzy / Expert System');

INSERT INTO subtopics (topic_id, kode, nama) VALUES
(2, 'BE',  'Backend Engineering'),
(2, 'FS',  'Fullstack Web Development'),
(2, 'MOB', 'Mobile App Development'),
(2, 'DB',  'Database Engineering'),
(2, 'SD',  'System Design');

INSERT INTO subtopics (topic_id, kode, nama) VALUES
(3, 'RS',  'Routing & Switching'),
(3, 'SEC', 'Network Security'),
(3, 'INF', 'Infrastructure & Server Administration'),
(3, 'MON', 'Network Monitoring & Automation'),
(3, 'WIFI','Wireless Networking & IoT Connectivity');

INSERT INTO subtopics (topic_id, kode, nama) VALUES
(4, 'UXR',  'UX Research & User Psychology'),
(4, 'PROTO','High-Fidelity Prototyping'),
(4, 'DSYS', 'Design Systems & UI Components'),
(4, 'IXD',  'Interaction Design (IxD)'),
(4, 'PD',   'Product Design (End-to-End)');


