--1
ALTER TABLE METemplateParams ADD [MEParamImageHeight] int
ALTER TABLE METemplateParams ADD [MEParamImageWidth] int

--2
UPDATE METemplateParams set [MEParamImageHeight] = 0
UPDATE METemplateParams set [MEParamImageWidth] = 0

--3
ALTER TABLE METemplateParams ALTER COLUMN [MEParamImageHeight] int not null
ALTER TABLE METemplateParams ALTER COLUMN  [MEParamImageWidth]  int not null

