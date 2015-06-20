// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestSample.Server.Infrastructure.Validation
{
    public class LenthBetweenInclusiveBoundsValidator<TProperty> : PropertyValidator
    {
        private int min;
        private int max;

        public LenthBetweenInclusiveBoundsValidator(int min, int max)
            : base("Property {PropertyName} " + String.Format("length is not between {0} and {1} items!", min, max))
        {
            this.min = min;
            this.max = max;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<TProperty>;

            if(list == null) 
            {
                return false;
            }
            
            if(list.Count() < min || list.Count() > max) 
            {
                return false;
            }
            
            return true;
        }
    }
}