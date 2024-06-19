-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CardsLogsChangeHistory
	-- Add the parameters for the stored procedure here
	@DN VARCHAR(255),
	@NewName VARCHAR(255) = '',
	@NewNumber VARCHAR(255) = '',
	@NewTypeOfDocument VARCHAR(255) = '',
	@NewSign VARCHAR(255) = '',
	@NewNumberOfDecision VARCHAR(255) = '',
	@NewA0 VARCHAR(255) = '',
	@NewA1 VARCHAR(255) = '',
	@NewA2 VARCHAR(255) = '',
	@NewA3 VARCHAR(255) = '',
	@NewA4 VARCHAR(255) = '',
	@NewOther VARCHAR(255) = '',
	@NewCount VARCHAR(255) = '',
	@NewOriginal VARCHAR(255) = '',
	@NewDublicate VARCHAR(255) = '',
	@NewIDOriginal VARCHAR(255) = '',
	@NewIDDublicate VARCHAR(255) = '',
	@NewDateOriginal VARCHAR(255) = '',
	@NewDateDublicate VARCHAR(255) = '',
	@NewLitera VARCHAR(255) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Name VARCHAR(255), @Number VARCHAR(255), @TypeOfDocument VARCHAR(255), @Sign VARCHAR(255), @NumberOfDecision VARCHAR(255), 
	@A0 VARCHAR(255), @A1 VARCHAR(255), @A2 VARCHAR(255), @A3 VARCHAR(255), @A4 VARCHAR(255), @Other VARCHAR(255), @Count VARCHAR(255), 
	@Original VARCHAR(255), @Dublicate VARCHAR(255), @IDOriginal VARCHAR(255), @IDDublicate VARCHAR(255), @DateOriginal VARCHAR(255), @DateDublicate VARCHAR(255), @Litera VARCHAR(255);
	SELECT @Name = Название, @Number = Подразделение, @TypeOfDocument = Вид_документа, @Sign = Знак_заказчика, @NumberOfDecision = Номер_решения, @A0 = A0, @A1 = A1, @A2 = A2, @A3 = A3, @A4 = A4, @Other = Другое,
	@Count = Количество, @Original = Подлинник, @Dublicate = Дубликат, @IDOriginal = ИН_подлинник, @IDDublicate = ИН_дубликат, @DateOriginal = Дата_подлинник, @DateDublicate = Дата_дубликат, @Litera = Литера
	FROM Cards
	WHERE ДН = @DN;

	UPDATE Cards
	SET Название = @NewName,
		Подразделение = @NewNumber,
		Вид_документа = @NewTypeOfDocument,
		Знак_заказчика = @NewSign,
		Номер_решения = @NewNumberOfDecision,
		A0 = @NewA0,
		A1 = @NewA1,
		A2 = @NewA2,
		A3 = @NewA3,
		A4 = @NewA4,
		Другое = @NewOther,
		Количество = @NewCount,
		Подлинник = @NewOriginal,
		Дубликат = @NewDublicate,
		ИН_подлинник = @NewIDOriginal,
		ИН_дубликат = @NewIDDublicate,
		Дата_подлинник = @NewDateOriginal,
		Дата_дубликат = @NewDateDublicate,
		Литера = @NewLitera
	WHERE ДН = @DN;

	INSERT INTO Logs (ДН, Старые_значения, Новые_значения, Изменено_пользователем, Дата_изменения)
	SELECT ДН, 
	CONCAT('Название: ', @Name, ', Подразделение: ', @Number, ', Вид документа: ', @TypeOfDocument, ', Знак заказчика: ,', @Sign, ', Номер решения: ', @NumberOfDecision, ', А0:', @A0, ', А1: ', @A1, ', А2: ', @A2,
	', А3: ', @A3, ', А4: ', @A4, ', Другое: ', @Other, ', Количество: ', @Count, ', Подлинник: ', @Original, ', Дубликат: ', @Dublicate, ', ИН подлинника: ', @IDOriginal, ', ИН дубликата: ', @IDDublicate, 
	', Дата подлинника: ', @DateOriginal, ', Дата дубликата: ', @DateDublicate, ', Литера: ', @Litera), 
	CONCAT('Название: ', Название, ', Подразделение: ', Подразделение, ', Вид документа: ', Вид_документа, ', Знак заказчика: ,', Знак_заказчика, ', Номер решения: ', Номер_решения, ', А0:', A0, ', А1: ', A1,
	', А2: ', A2, ', А3: ', A3, ', А4: ', A4, ', Другое: ', Другое, ', Количество: ', Количество, ', Подлинник: ', Подлинник, ', Дубликат: ', Дубликат, ', ИН подлинника: ', ИН_подлинник, ', ИН дубликата: ', ИН_дубликат, 
	', Дата подлинника: ', Дата_подлинник, ', Дата дубликата: ', Дата_дубликат, ', Литера: ', Литера), 
	'Пользователь', 
	GETDATE()
	FROM Cards
	WHERE ДН = @DN;
END
GO
