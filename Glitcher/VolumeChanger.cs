using NAudio.CoreAudioApi;

namespace Glitcher
{
    /// <summary>
    /// A class to adjust the system's audio volume for the default audio output device.
    /// </summary>
    internal class VolumeChanger
    {
        private readonly MMDeviceEnumerator enumerator;
        private readonly MMDevice? defaultDevice;

        /// <summary>
        /// Constructor that initializes the VolumeChanger by retrieving the default audio output device.
        /// </summary>
        public VolumeChanger()
        {
            try
            {
                enumerator = new MMDeviceEnumerator();
                defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            }
            catch
            {
                defaultDevice = null;
            }
        }

        /// <summary>
        /// Adjusts the volume of the default audio output device.
        /// </summary>
        /// <param name="adjustment">The amount to adjust the volume. Positive values increase volume, negative values decrease volume.</param>
        public void AdjustVolume(int adjustment)
        {
            if (defaultDevice == null)
                return;

            float value = adjustment / 100;
            float currentVolume = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar;
            float newVolume = Math.Clamp(currentVolume + value, 0.0f, 1.0f);
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;
        }
    }
}
