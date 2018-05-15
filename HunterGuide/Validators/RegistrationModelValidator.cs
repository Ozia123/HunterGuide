﻿using HunterGuide.EF;
using HunterGuide.Helpers;
using HunterGuide.Interfaces;
using HunterGuide.Models;
using HunterGuide.Singletons;
using System.Linq;

namespace HunterGuide.Validators {
    public class RegistrationModelValidator : ICustomValidator<RegistrationModel> 
    {
        private readonly ApplicationContext context;
        private CustomValidator<RegistrationModel> customValidator;

        public RegistrationModelValidator() 
        {
            context = ContextProvider.GetApplicationContext();
            customValidator = new CustomValidator<RegistrationModel>();

            SetDefaultRules();
        }

        public void Validate(RegistrationModel model) 
        {
            customValidator.Validate(model);
        }

        private void SetDefaultRules() 
        {
            customValidator
                .RuleFor(rm => rm.Username.Length >= 3)
                .WithMessage("Username must be at least 3 characters long")
                .RuleFor(rm => !context.Users.Any(u => u.Username.Equals(rm.Username)))
                .WithMessage("User with username {0} already registered, please peek another one");

            customValidator
                .RuleFor(rm => rm.FirstName.Length >= 3)
                .WithMessage("First name must be at least 3 characters long");

            customValidator
                .RuleFor(rm => rm.LastName.Length >= 3)
                .WithMessage("First name must be at least 3 characters long");

            customValidator
                .RuleFor(rm => rm.Password.Length >= 5)
                .WithMessage("Password must be at least 5 characters long");

            customValidator
                .RuleFor(rm => RegexMatcher.IsMatch(rm.RepeatPassword, rm.Password))
                .WithMessage("Passwords do not match");
        }
    }
}
