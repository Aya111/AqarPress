ALTER TABLE [dbo].[ProjectDiscussion] ALTER COLUMN message_body NVARCHAR(500) NULL

CREATE TABLE Attachments(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	path NVARCHAR(100) NOT NULL,
	project_discussion_id INT REFERENCES ProjectDiscussion(id),
	comment NVARCHAR(500) NULL
);

