﻿namespace SharpDeck.Interactivity
{
    using System.Threading;
    using System.Threading.Tasks;
    using SharpDeck.Enums;

    /// <summary>
    /// Provides properties and methods for managing a drill-down.
    /// </summary>
    /// <typeparam name="TItem">The type of the item handled by the drill-down.</typeparam>
    public interface IDrillDownManager<TItem>
    {
        /// <summary>
        /// Gets the action UUID contained within the profile.
        /// </summary>
        string ActionUUID { get; }

        /// <summary>
        /// Gets the name of the profile responsible for showing this drill-down's action. This should loosely match the manifest.json; the device the drill-down will be rendered
        /// on is appended as a suffix, i.e. "Mini", "" (Stream Deck), "XL", or "Mobile".
        /// </summary>
        /// <example>When the manifest.json has a profile name of "MyProfileXL", target device Stream Deck XL, this value will be "MyProfile".</example>
        string Profile { get; }

        /// <summary>
        /// Gets the list of supported devices.
        /// </summary>
        /// <remarks><see cref="DeviceType.CorsairGKeys"/> is never supported.</remarks>
        DeviceType[] SupportedDevices { get; }

        /// <summary>
        /// Called when an item becomes visible within the drill-down.
        /// </summary>
        /// <param name="item">The item that has become visible.</param>
        /// <param name="feedbackProvider">The feedback provider; this enables the button that represents the <paramref name="item"/> to be updated accordingly.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task of showing the item.</returns>
        Task OnShowAsync(TItem item, IButtonFeedbackProvider feedbackProvider, CancellationToken cancellationToken);

        /// <summary>
        /// Called when the user selects an item.
        /// </summary>
        /// <param name="item">The selected item.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task of handling the selection.</returns>
        Task OnSelectedAsync(TItem item, CancellationToken cancellationToken);
    }
}
