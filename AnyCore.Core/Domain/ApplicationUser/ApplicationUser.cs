using System;

namespace AnyCore.Core.Domain.ApplicationUser
{
    public class ApplicationUser
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            CreatedOnUtc = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime? LastLoginDateUtc { get; set; }

        public int FailedLoginAttempts { get; set; }

        public DateTime? CannotLoginUntilDateUtc { get; set; }
    }
}
