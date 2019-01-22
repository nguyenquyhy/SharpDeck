﻿namespace SharpDeck.Extensions
{
    using Newtonsoft.Json.Linq;
    using System;

    /// <summary>
    /// Provides extension methods for <see cref="JObject"/>.
    /// </summary>
    public static class JObjectExtensions
    {
        /// <summary>
        /// Tries the get the <see cref="string"/> for the specified <paramref name="propertyName"/>, ignoring case.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> instance.</param>
        /// <param name="propertyName">Name of the property; otherwise null.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> when the value was found; otherwise <c>false</c>.</returns>
        public static bool TryGetString(this JObject obj, string propertyName, out string value)
        {
            if (obj.TryGetValue(propertyName, StringComparison.OrdinalIgnoreCase, out var token))
            {
                value = token.Value<string>();
                return true;
            }

            value = null;
            return false;
        }

    }
}
