using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.Models;

namespace FlavorWorld.Domain.Common.Events;

public record EmailDomainEvent(EmailSetting EmailSetting) : IDomainEvent;