namespace Secop.Core.Domain.Enums
{
    public enum CreditRiskLevelType
    {
        None = 0,
        VeryHighRisk = 1, // En riskli(1000-1199)
        HighRisk = 2,     // Orta riskli(1200-1399)
        MediumRisk = 3,   // Az riskli(1400-1599)
        Good = 4,         // İyi(1600-1799)
        Excellent = 5     // Çok iyi(1800-1999)
    }
}
