// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestSample.Server.Infrastructure.Validation
{
    public class AllValidator<TProperty> : PropertyValidator   
    {
        private Func<TProperty, bool> predicate;

        public AllValidator(Func<TProperty, bool> predicate, string message)
            : base(message)
        {
            this.predicate = predicate;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IEnumerable<TProperty>;

            if(list == null) 
            {
                return false;
            }

            return list.All(predicate);
        }
    }
}