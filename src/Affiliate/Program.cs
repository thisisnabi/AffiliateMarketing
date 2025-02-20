using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();

public class Affilate
{
    public string Id { get; set; }

    public string UserId { get; set; }

    public string ReferralId { get; set; }

    public ICollection<Joiner> Joiners { get; set; }

    public ICollection<AffilateAction> Earns { get; set; }

    public ICollection<PayOut> PayOuts { get; set; }
}

public class Joiner
{
    public string AffiliateId { get; set; }

    public string Username { get; set; }

    public DateTime JoinedOn { get; set; }
}

public class AffilateAction
{
    public long Id { get; set; }

    public string AffilateId { get; set; }

    public decimal Earn { get; set; }

    public string Description { get; set; }
}

public class PayOut
{
    public int Id { get; set; }

    public string AffilateId { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreateAt { get; set; }

    public bool IsPaid { get; set; }
}

