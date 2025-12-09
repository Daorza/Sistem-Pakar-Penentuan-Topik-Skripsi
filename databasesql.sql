-- ================================================
-- TABLE: topics
-- ================================================
CREATE TABLE [dbo].[topics] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [kode]       NVARCHAR (10) NOT NULL,
    [nama]       NVARCHAR (100) NOT NULL,
    [is_active]  BIT DEFAULT ((1)) NULL,
    [created_at] DATETIME DEFAULT (getdate()) NULL,
    [updated_at] DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ================================================
-- TABLE: subtopics
-- ================================================
CREATE TABLE [dbo].[subtopics] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [topic_id]   INT NOT NULL,
    [kode]       NVARCHAR (20) NOT NULL,
    [nama]       NVARCHAR (150) NOT NULL,
    [is_active]  BIT DEFAULT ((1)) NULL,
    [created_at] DATETIME DEFAULT (getdate()) NULL,
    [updated_at] DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([topic_id]) REFERENCES [dbo].[topics] ([id])
);
GO

-- ================================================
-- TABLE: users
-- ================================================
CREATE TABLE [dbo].[users] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [nama]       NVARCHAR (100) NOT NULL,
    [nim]        NVARCHAR (20) NOT NULL,
    [prodi]      NVARCHAR (100) NOT NULL,
    [password]   NVARCHAR(255) NULL,
    [role]       NVARCHAR(20) DEFAULT 'user' NULL,
    [is_active]  BIT DEFAULT ((1)) NULL,
    [created_at] DATETIME DEFAULT (getdate()) NULL,
    [updated_at] DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT CK_users_role CHECK ([role] IN ('admin', 'user'))
);
GO

-- ================================================
-- TABLE: questions
-- ================================================
CREATE TABLE [dbo].[questions] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [pertanyaan] NVARCHAR (MAX) NOT NULL,
    [kategori]   NVARCHAR (20) NULL,
    [level]      INT NOT NULL,
    [is_active]  BIT DEFAULT ((1)) NULL,
    [created_at] DATETIME DEFAULT (getdate()) NULL,
    [updated_at] DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CHECK ([kategori] IN ('SUBTOPIK','REKOMENDASI','METODE','TOPIK'))
);
GO

-- ================================================
-- TABLE: question_rules
-- ================================================
CREATE TABLE [dbo].[question_rules] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [question_id] INT NOT NULL,
    [topic_id]    INT NULL,
    [subtopic_id] INT NULL,
    [metode]      NVARCHAR (20) NULL,
    [rekomendasi] NVARCHAR (20) NULL,
    [cf_pakar]    FLOAT (53) DEFAULT ((1)) NULL,
    [is_active]   BIT DEFAULT ((1)) NULL,
    [created_at]  DATETIME DEFAULT (getdate()) NULL,
    [updated_at]  DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([question_id]) REFERENCES [dbo].[questions] ([id]),
    FOREIGN KEY ([topic_id]) REFERENCES [dbo].[topics] ([id]),
    FOREIGN KEY ([subtopic_id]) REFERENCES [dbo].[subtopics] ([id]),
    CHECK ([metode] IN ('KUANTITATIF','KUALITATIF')),
    CHECK ([rekomendasi] IN ('MEMBUAT','ANALISIS'))
);
GO

-- ================================================
-- TABLE: user_answers
-- ================================================
CREATE TABLE [dbo].[user_answers] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [user_id]     INT NOT NULL,
    [question_id] INT NOT NULL,
    [skala]       INT NOT NULL,
    [cf_user]     FLOAT (53) NOT NULL,
    [created_at]  DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id]),
    FOREIGN KEY ([question_id]) REFERENCES [dbo].[questions] ([id])
);
GO

-- ================================================
-- TABLE: results
-- ================================================
CREATE TABLE [dbo].[results] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [user_id]     INT NOT NULL,
    [metode]      NVARCHAR (20) NULL,
    [rekomendasi] NVARCHAR (20) NULL,
    [created_at]  DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id]),
    CHECK ([metode] IN ('KUANTITATIF','KUALITATIF')),
    CHECK ([rekomendasi] IN ('MEMBUAT','ANALISIS'))
);
GO

-- ================================================
-- TABLE: result_rankings
-- ================================================
CREATE TABLE [dbo].[result_rankings] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [user_id]    INT NOT NULL,
    [tipe]       NVARCHAR (20) NULL,
    [ref_id]     INT NOT NULL,
    [cf_value]   FLOAT (53) NOT NULL,
    [persentase] INT NOT NULL,
    [ranking]    INT NOT NULL,
    [created_at] DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id]),
    CHECK ([tipe] IN ('SUBTOPIK','TOPIK'))
);
GO
