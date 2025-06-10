using NUnit.Framework;
using SavingsAccount;

namespace SavingsAccountTests;

[TestFixture]
public class WithdrawalValidatorTests
{
    // TC1 - Todos los valores válidos
    [Test]
    public void TC1_AllValidConditions_ShouldAllowWithdrawal()
    {
        var result = WithdrawalValidator.CanWithdraw(
            isActive: true,
            balance: 1000,
            dailyLimit: 500,
            isBlocked: false,
            amount: 100
        );
        Assert.IsTrue(result);
    }

    // TC2 - Cuenta inactiva
    [Test]
    public void TC2_InactiveAccount_ShouldDenyWithdrawal()
    {
        var result = WithdrawalValidator.CanWithdraw(
            isActive: false,
            balance: 1000,
            dailyLimit: 500,
            isBlocked: false,
            amount: 100
        );
        Assert.IsFalse(result);
    }

    // TC3 - Saldo insuficiente
    [Test]
    public void TC3_InsufficientBalance_ShouldDenyWithdrawal()
    {
        var result = WithdrawalValidator.CanWithdraw(
            isActive: true,
            balance: 50,
            dailyLimit: 500,
            isBlocked: false,
            amount: 100
        );
        Assert.IsFalse(result);
    }

    // TC4 - Excede límite diario
    [Test]
    public void TC4_ExceedsDailyLimit_ShouldDenyWithdrawal()
    {
        var result = WithdrawalValidator.CanWithdraw(
            isActive: true,
            balance: 1000,
            dailyLimit: 100,
            isBlocked: false,
            amount: 200
        );
        Assert.IsFalse(result);
    }

    // TC5 - Cuenta bloqueada por fraude
    [Test]
    public void TC5_BlockedAccount_ShouldDenyWithdrawal()
    {
        var result = WithdrawalValidator.CanWithdraw(
            isActive: true,
            balance: 1000,
            dailyLimit: 500,
            isBlocked: true,
            amount: 100
        );
        Assert.IsFalse(result);
    }

    // TC6 - Monto no múltiplo de 10
    [Test]
    public void TC6_AmountNotMultipleOfTen_ShouldDenyWithdrawal()
    {
        var result = WithdrawalValidator.CanWithdraw(
            isActive: true,
            balance: 1000,
            dailyLimit: 500,
            isBlocked: false,
            amount: 105
        );
        Assert.IsFalse(result);
    }
}
