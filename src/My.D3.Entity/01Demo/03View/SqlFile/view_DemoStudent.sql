
ALTER VIEW [dbo].[view_DemoStudent]
AS
SELECT StudentGUID,
       StuName,
       Age,
       Birthday,
       Height,
       IsVIP,
       ClassGUID,
       IsDeleted,
       CreateTime,
       CreateGUID,
       CreatedName,
       ModifiedTime,
       ModifiedGUID,
       ModifiedName,
	   SexType
FROM dbo.Demo_Student;