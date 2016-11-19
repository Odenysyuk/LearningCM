GO
SELECT COUNT(*) AS BeforeTruncateCount 
FROM dbo.Question;
GO
TRUNCATE TABLE dbo.Question;
GO
SELECT COUNT(*) AS AfterTruncateCount 
FROM dbo.Words;
GO

Select
*
FROM dbo.Words
GO

ALTER Table Words
ADD Translation NVARCHAR(100)

GO

SELECT * 
FROM sys.foreign_keys
WHERE referenced_object_id = object_id('Words')
GO 

SELECT 
    'ALTER TABLE ' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '.[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT ' + name
FROM sys.foreign_keys
WHERE referenced_object_id = object_id('Words')
GO
ALTER TABLE dbo.[Sounds] DROP CONSTRAINT FK__Sounds__ID_Word__1BFD2C07
GO
ALTER TABLE dbo.[LearntWords] DROP CONSTRAINT FK__LearntWor__ID_Wo__239E4DCF
GO

DROP TABLE Words

INSERT INTO Words(Name, Translation, ID_Block, ID_Lesson, ID_Stage) VALUES ('Hight seller', 'Sell product', 1,2,3);
