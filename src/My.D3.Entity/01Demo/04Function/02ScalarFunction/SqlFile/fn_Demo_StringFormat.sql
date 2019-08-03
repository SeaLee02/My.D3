IF (OBJECT_ID('fn_Demo_StringFormat') IS NOT NULL)
BEGIN
    DROP FUNCTION fn_Demo_StringFormat;
END;
GO


-- =============================================
-- Author:		<sealee>
-- Create date: <2018-09-13>
-- Description:	<说明: 模拟C#stringformat >
-- Example:  declare @Ret varchar(1024)='{0},Hello,{1}';set @Ret = dbo.fn_Demo_StringFormat(@Ret,'lihai','test',DEFAULT,DEFAULT,DEFAULT);SELECT @Ret
-- =============================================
CREATE FUNCTION [dbo].[fn_Demo_StringFormat]
(
    @Str VARCHAR(MAX),
    @Param1 VARCHAR(MAX),
    @Param2 VARCHAR(MAX) = '',
    @Param3 VARCHAR(MAX) = '',
    @Param4 VARCHAR(MAX) = '',
    @Param5 VARCHAR(MAX) = ''
)
RETURNS VARCHAR(MAX)
AS
BEGIN
    DECLARE @StrReturn AS VARCHAR(MAX);
    SET @StrReturn = REPLACE(@Str, '{0}', @Param1);
    SET @StrReturn = REPLACE(@StrReturn, '{1}', @Param2);
    SET @StrReturn = REPLACE(@StrReturn, '{2}', @Param3);
    SET @StrReturn = REPLACE(@StrReturn, '{3}', @Param4);
    SET @StrReturn = REPLACE(@StrReturn, '{4}', @Param5);
    RETURN @StrReturn;
END;
GO

