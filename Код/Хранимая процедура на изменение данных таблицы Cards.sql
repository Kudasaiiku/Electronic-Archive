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
	SELECT @Name = ��������, @Number = �������������, @TypeOfDocument = ���_���������, @Sign = ����_���������, @NumberOfDecision = �����_�������, @A0 = A0, @A1 = A1, @A2 = A2, @A3 = A3, @A4 = A4, @Other = ������,
	@Count = ����������, @Original = ���������, @Dublicate = ��������, @IDOriginal = ��_���������, @IDDublicate = ��_��������, @DateOriginal = ����_���������, @DateDublicate = ����_��������, @Litera = ������
	FROM Cards
	WHERE �� = @DN;

	UPDATE Cards
	SET �������� = @NewName,
		������������� = @NewNumber,
		���_��������� = @NewTypeOfDocument,
		����_��������� = @NewSign,
		�����_������� = @NewNumberOfDecision,
		A0 = @NewA0,
		A1 = @NewA1,
		A2 = @NewA2,
		A3 = @NewA3,
		A4 = @NewA4,
		������ = @NewOther,
		���������� = @NewCount,
		��������� = @NewOriginal,
		�������� = @NewDublicate,
		��_��������� = @NewIDOriginal,
		��_�������� = @NewIDDublicate,
		����_��������� = @NewDateOriginal,
		����_�������� = @NewDateDublicate,
		������ = @NewLitera
	WHERE �� = @DN;

	INSERT INTO Logs (��, ������_��������, �����_��������, ��������_�������������, ����_���������)
	SELECT ��, 
	CONCAT('��������: ', @Name, ', �������������: ', @Number, ', ��� ���������: ', @TypeOfDocument, ', ���� ���������: ,', @Sign, ', ����� �������: ', @NumberOfDecision, ', �0:', @A0, ', �1: ', @A1, ', �2: ', @A2,
	', �3: ', @A3, ', �4: ', @A4, ', ������: ', @Other, ', ����������: ', @Count, ', ���������: ', @Original, ', ��������: ', @Dublicate, ', �� ����������: ', @IDOriginal, ', �� ���������: ', @IDDublicate, 
	', ���� ����������: ', @DateOriginal, ', ���� ���������: ', @DateDublicate, ', ������: ', @Litera), 
	CONCAT('��������: ', ��������, ', �������������: ', �������������, ', ��� ���������: ', ���_���������, ', ���� ���������: ,', ����_���������, ', ����� �������: ', �����_�������, ', �0:', A0, ', �1: ', A1,
	', �2: ', A2, ', �3: ', A3, ', �4: ', A4, ', ������: ', ������, ', ����������: ', ����������, ', ���������: ', ���������, ', ��������: ', ��������, ', �� ����������: ', ��_���������, ', �� ���������: ', ��_��������, 
	', ���� ����������: ', ����_���������, ', ���� ���������: ', ����_��������, ', ������: ', ������), 
	'������������', 
	GETDATE()
	FROM Cards
	WHERE �� = @DN;
END
GO
