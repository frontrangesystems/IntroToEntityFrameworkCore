PRINT N'Creating [dbo].[__EFMigrationsHistory]...';


GO
CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
);


GO
PRINT N'Creating [dbo].[Actor]...';


GO
CREATE TABLE [dbo].[Actor] (
    [ActorId]   INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED ([ActorId] ASC)
);


GO
PRINT N'Creating [dbo].[Category]...';


GO
CREATE TABLE [dbo].[Category] (
    [CategoryId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);


GO
PRINT N'Creating [dbo].[Film]...';


GO
CREATE TABLE [dbo].[Film] (
    [FilmId]      INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [RatingCode]  NVARCHAR (MAX) NULL,
    [RatingId]    INT            NULL,
    [ReleaseYear] INT            NULL,
    [Runtime]     INT            NULL,
    [Title]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Film] PRIMARY KEY CLUSTERED ([FilmId] ASC)
);


GO
PRINT N'Creating [dbo].[Film].[IX_Film_RatingId]...';


GO
CREATE NONCLUSTERED INDEX [IX_Film_RatingId]
    ON [dbo].[Film]([RatingId] ASC);


GO
PRINT N'Creating [dbo].[FilmActor]...';


GO
CREATE TABLE [dbo].[FilmActor] (
    [FilmId]  INT NOT NULL,
    [ActorId] INT NOT NULL,
    CONSTRAINT [PK_FilmActor] PRIMARY KEY CLUSTERED ([FilmId] ASC, [ActorId] ASC)
);


GO
PRINT N'Creating [dbo].[FilmActor].[IX_FilmActor_ActorId]...';


GO
CREATE NONCLUSTERED INDEX [IX_FilmActor_ActorId]
    ON [dbo].[FilmActor]([ActorId] ASC);


GO
PRINT N'Creating [dbo].[FilmCategory]...';


GO
CREATE TABLE [dbo].[FilmCategory] (
    [FilmId]     INT NOT NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT [PK_FilmCategory] PRIMARY KEY CLUSTERED ([FilmId] ASC, [CategoryId] ASC)
);


GO
PRINT N'Creating [dbo].[FilmCategory].[IX_FilmCategory_CategoryId]...';


GO
CREATE NONCLUSTERED INDEX [IX_FilmCategory_CategoryId]
    ON [dbo].[FilmCategory]([CategoryId] ASC);


GO
PRINT N'Creating [dbo].[FilmImage]...';


GO
CREATE TABLE [dbo].[FilmImage] (
    [FilmImageId] INT            IDENTITY (1, 1) NOT NULL,
    [FilmId]      INT            NOT NULL,
    [ImageUrl]    NVARCHAR (MAX) NULL,
    [Title]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_FilmImage] PRIMARY KEY CLUSTERED ([FilmImageId] ASC)
);


GO
PRINT N'Creating [dbo].[FilmImage].[IX_FilmImage_FilmId]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_FilmImage_FilmId]
    ON [dbo].[FilmImage]([FilmId] ASC);


GO
PRINT N'Creating [dbo].[Rating]...';


GO
CREATE TABLE [dbo].[Rating] (
    [RatingId] INT            IDENTITY (1, 1) NOT NULL,
    [Code]     NVARCHAR (MAX) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED ([RatingId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Film_Rating_RatingId]...';


GO
ALTER TABLE [dbo].[Film] WITH NOCHECK
    ADD CONSTRAINT [FK_Film_Rating_RatingId] FOREIGN KEY ([RatingId]) REFERENCES [dbo].[Rating] ([RatingId]);


GO
PRINT N'Creating [dbo].[FK_FilmActor_Actor_ActorId]...';


GO
ALTER TABLE [dbo].[FilmActor] WITH NOCHECK
    ADD CONSTRAINT [FK_FilmActor_Actor_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [dbo].[Actor] ([ActorId]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_FilmActor_Film_FilmId]...';


GO
ALTER TABLE [dbo].[FilmActor] WITH NOCHECK
    ADD CONSTRAINT [FK_FilmActor_Film_FilmId] FOREIGN KEY ([FilmId]) REFERENCES [dbo].[Film] ([FilmId]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_FilmCategory_Category_CategoryId]...';


GO
ALTER TABLE [dbo].[FilmCategory] WITH NOCHECK
    ADD CONSTRAINT [FK_FilmCategory_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_FilmCategory_Film_FilmId]...';


GO
ALTER TABLE [dbo].[FilmCategory] WITH NOCHECK
    ADD CONSTRAINT [FK_FilmCategory_Film_FilmId] FOREIGN KEY ([FilmId]) REFERENCES [dbo].[Film] ([FilmId]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_FilmImage_Film_FilmId]...';


GO
ALTER TABLE [dbo].[FilmImage] WITH NOCHECK
    ADD CONSTRAINT [FK_FilmImage_Film_FilmId] FOREIGN KEY ([FilmId]) REFERENCES [dbo].[Film] ([FilmId]) ON DELETE CASCADE;


GO
PRINT N'Checking existing data against newly created constraints';


GO
ALTER TABLE [dbo].[Film] WITH CHECK CHECK CONSTRAINT [FK_Film_Rating_RatingId];

ALTER TABLE [dbo].[FilmActor] WITH CHECK CHECK CONSTRAINT [FK_FilmActor_Actor_ActorId];

ALTER TABLE [dbo].[FilmActor] WITH CHECK CHECK CONSTRAINT [FK_FilmActor_Film_FilmId];

ALTER TABLE [dbo].[FilmCategory] WITH CHECK CHECK CONSTRAINT [FK_FilmCategory_Category_CategoryId];

ALTER TABLE [dbo].[FilmCategory] WITH CHECK CHECK CONSTRAINT [FK_FilmCategory_Film_FilmId];

ALTER TABLE [dbo].[FilmImage] WITH CHECK CHECK CONSTRAINT [FK_FilmImage_Film_FilmId];


GO
PRINT N'Update complete.';


GO
