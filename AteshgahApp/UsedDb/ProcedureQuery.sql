
CREATE PROCEDURE [dbo].[ESTIMATE_LOAN_AMOUNT]
@LoanAmount MONEY,
@InvoiceOrderN INT,
@LoanPeriod INT,
@InterestRate INT
AS 
 BEGIN
   
    DECLARE @Estimated MONEY
	DECLARE @UnPaidAmount MONEY

	SET @UnPaidAmount = ((@LoanPeriod - @InvoiceOrderN +1 ) * @LoanAmount ) / @InvoiceOrderN;
	SET @Estimated = @LoanAmount / @LoanPeriod + (@UnPaidAmount * @InterestRate) / 100
    SELECT @Estimated
 END
GO
