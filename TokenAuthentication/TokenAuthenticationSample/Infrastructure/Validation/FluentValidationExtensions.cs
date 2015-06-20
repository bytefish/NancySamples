// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentValidation;
using System;
using System.Collections.Generic;

namespace RestSample.Server.Infrastructure.Validation
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, IList<TProperty>> LengthBetweenInclusiveBounds<T, TProperty>(this IRuleBuilder<T, IList<TProperty>> ruleBuilder, int min, int max)
        {
            return ruleBuilder.SetValidator(new LenthBetweenInclusiveBoundsValidator<TProperty>(min, max));
        }

        public static IRuleBuilderOptions<T, string> IsAlphaNumeric<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new AlphaNumericValidator());
        }

        public static IRuleBuilderOptions<T, IList<TProperty>> All<T, TProperty>(this IRuleBuilder<T, IList<TProperty>> ruleBuilder, Func<TProperty, bool> predicate, string message)
            where TProperty : class
        {
            return ruleBuilder.SetValidator(new AllValidator<TProperty>(predicate, message));
        }
    }
}