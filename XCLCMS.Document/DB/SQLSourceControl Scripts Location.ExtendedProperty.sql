USE [XCLCMS]
GO
/****** Object:  ExtendedProperty [SQLSourceControl Scripts Location]    Script Date: 03/21/2015 10:00:29 ******/
EXEC sys.sp_addextendedproperty @name=N'SQLSourceControl Scripts Location', @value=N'<?xml version="1.0" encoding="utf-16" standalone="yes"?>
<ISOCCompareLocation version="1" type="TfsLocation">
  <ServerUrl>http://localhost:8080/tfs/mytask</ServerUrl>
  <SourceControlFolder>$/DB/XCLCMS</SourceControlFolder>
</ISOCCompareLocation>'
GO
