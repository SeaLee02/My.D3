IF (OBJECT_ID('fn_Demo_GetDays') IS NOT NULL)
BEGIN
    DROP FUNCTION fn_Demo_GetDays;
END;
GO


-- =============================================
-- Author:		<sealee>
-- Create date: <2018-09-13>
-- Description:	<说明: 获取输入和输出时间相隔的天数>
-- Example:  SELECT * FROM  dbo.fn_Demo_GetDays('2018-01-01','2018-01-31')
-- =============================================
CREATE FUNCTION [dbo].[fn_Demo_GetDays]
(
    @StartDate DATE,
    @EndDate DATE
)
RETURNS @t TABLE
(
    Days DATETIME NOT NULL
)
AS
BEGIN
    INSERT INTO @t
    (
        Days
    )
    SELECT DATEADD(DAY, number, @StartDate) AS Days
    FROM master..spt_values
    WHERE type = 'P'
          AND DATEADD(DAY, number, @StartDate) <= @EndDate;
    RETURN;
END;
GO
