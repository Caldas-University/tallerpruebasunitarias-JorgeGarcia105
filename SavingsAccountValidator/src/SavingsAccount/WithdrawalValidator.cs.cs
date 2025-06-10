namespace SavingsAccount;

public static class WithdrawalValidator
{
    public static bool CanWithdraw(
        bool isActive,
        decimal balance,
        decimal dailyLimit,
        bool isBlocked,
        decimal amount
    )
    {
        if (!isActive) return false;
        if (isBlocked) return false;
        if (amount > balance) return false;
        if (amount > dailyLimit) return false;
        if (amount % 10 != 0) return false;

        return true;
    }
}
