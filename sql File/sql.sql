CREATE TABLE Blog
(
BLOGID INT IDENTITY(1,1) NOT NULL,
BLOGDATA VARCHAR(1024),
BLOGDATE DATETIME  CONSTRAINT [DF_Blog_BLOGDATE] DEFAULT (GETDATE())
CONSTRAINT PK_Blog_BLOGID PRIMARY KEY (BrandID)
)


 
Create procedure prcBlog
(
    @SpMode INT,
	@BLOGID	bigint=NULL,
	@BLOGDATA	nvarchar(1024)=NULL,
)	
As
Begin
	IF(@SpMode = 1)	---- Inserting New Record
	BEGIN
			insert into Blog
				(BLOGDATA)
			values
				(@BLOGDATA)
		 
		
	END
	ELSE IF( @SpMode = 2)	---- Updating Existing Record 
	BEGIN
		
			update Blog set 
				BLOGDATA=@BLOGDATA
			where BLOGID=@BLOGID
	
	END
	ELSE IF(@SpMode = 3)		---- Deleting Record 
	BEGIN
		delete from BLOG where BLOGID=@BLOGID
	END
	ELSE IF(@SpMode = 4)		---- Select Record 
	BEGIN
		Select BLOGID,BLOGDATA from BLOG
	END
	 
End