namespace Registration.Data;

using Components.StateMachines;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class RegistrationStateInstanceMap : SagaClassMap<RegistrationState>
{
    protected override void Configure(EntityTypeBuilder<RegistrationState> entity, ModelBuilder model)
    {
        entity.Property(x => x.ParticipantEmailAddress);
        entity.Property(x => x.ParticipantCategory);
        entity.Property(x => x.ParticipantLicenseNumber);
        entity.Property(x => x.ParticipantLicenseExpirationDate);
        entity.Property(x => x.RegistrationId);
        entity.Property(x => x.CardNumber);
        entity.Property(x => x.EventId);
        entity.Property(x => x.RaceId);
        entity.Property(x => x.Reason);
        entity.Property(x => x.RetryAttempt);
        entity.Property(x => x.ScheduleRetryToken);
    }
}