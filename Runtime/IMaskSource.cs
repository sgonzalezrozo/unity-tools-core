using UnityEngine;

namespace ToolsCore
{
    /// <summary>
    /// Abstraction for objects that provide mask shape data for UI components.
    /// Decouples mask calculation from specific UI implementations.
    /// Allows any shape/component to provide mask data via a common interface.
    /// </summary>
    public interface IMaskSource
    {
        /// <summary>Gets whether the left endpoint has a shape (not straight).</summary>
        bool LeftHasShape { get; }

        /// <summary>Gets whether the right endpoint has a shape (not straight).</summary>
        bool RightHasShape { get; }

        /// <summary>
        /// Gets the pixel width of the left endpoint.
        /// Used to calculate where the curve starts in world space.
        /// </summary>
        /// <param name="parentHeight">Height of the parent rect for percentage conversion</param>
        /// <returns>Pixel width of left endpoint (0 if no shape)</returns>
        float GetLeftEndpointPixelWidth(float parentHeight);

        /// <summary>
        /// Gets the pixel width of the right endpoint.
        /// Used to calculate where the curve ends in world space.
        /// </summary>
        /// <param name="parentHeight">Height of the parent rect for percentage conversion</param>
        /// <returns>Pixel width of right endpoint (0 if no shape)</returns>
        float GetRightEndpointPixelWidth(float parentHeight);

        /// <summary>Gets the texture for left endpoint shape rendering (null if straight).</summary>
        Texture GetLeftEndpointTexture();

        /// <summary>Gets the texture for right endpoint shape rendering (null if straight).</summary>
        Texture GetRightEndpointTexture();

        /// <summary>Show or hide the base visual representation.</summary>
        void SetBaseVisibility(bool visible);
    }
}

