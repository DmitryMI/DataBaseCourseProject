using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseProjectApplication.SecSystem;
using NAudio.Wave;

namespace CourseProjectApplication.Ui
{
    public partial class VoiceSampleEditor : Form
    {
        public const int SampleDurationSeconds = 5;

        private int _userId;
        
        private ISecSystem _secSystem;
        private List<Action> _playbackStoppedActions = new List<Action>();
        private byte[] _sampleBuffer;

        public VoiceSampleEditor(int userId, ISecSystem secSystem)
        {
            _userId = userId;
            _secSystem = secSystem;
            InitializeComponent();
        }

        private void PlaySample_Click(object sender, EventArgs e)
        {
            if(_sampleBuffer != null)
                PlayBufferedSample();
            else
            {
                MessageBox.Show("Sample buffer was empty!", "Internal error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void PlayBufferedSample()
        {
            void EnableButton()
            {
                PlaySampleButton.Enabled = true;
                RecordSampleButton.Enabled = true;
            }

            PlaySampleButton.Enabled = false;
            RecordSampleButton.Enabled = false;
            _playbackStoppedActions.Add(EnableButton);

            PlaySound(_sampleBuffer);
        }

        private void PlaySound(byte[] sample)
        {
            MemoryStream ms = new MemoryStream(sample);

            WaveOutEvent waveOut = new WaveOutEvent();
            WaveFileReader reader = new WaveFileReader(ms);
            waveOut.Init(reader);
            waveOut.PlaybackStopped += OnPlaybackStopped;
            waveOut.Play();
        }

        private void OnPlaybackStopped(object sender, EventArgs args)
        {
            
            foreach (var action in _playbackStoppedActions)
            {
                action();
            }

            _playbackStoppedActions.Clear();
        }

        private void VoiceSampleEditor_Load(object sender, EventArgs e)
        {
            byte[] sample = _secSystem.GetVoiceSample(_userId);

            if (sample == null)
            {
                _sampleBuffer = null;
            }
            else
            {
                _sampleBuffer = sample;
            }

            PlaySampleButton.Enabled = _sampleBuffer != null;
        }

        private void SetSample_Click(object sender, EventArgs e)
        {
            RecordSampleStart(SampleDurationSeconds);
        }

        private void RecordSampleStart(int durationSeconds)
        {
            RecordingProgressBar.Value = 0;

            PlaySampleButton.Enabled = false;
            RecordSampleButton.Enabled = false;

            var waveIn = new WaveInEvent();
            WaveFileWriter writer = null;
            int bufferSize = waveIn.WaveFormat.AverageBytesPerSecond * (durationSeconds + 1);
            int maximumSize = waveIn.WaveFormat.AverageBytesPerSecond * (durationSeconds);
            _sampleBuffer = new byte[bufferSize];
            MemoryStream ms = new MemoryStream(_sampleBuffer);
            writer = new WaveFileWriter(ms, waveIn.WaveFormat);
            waveIn.StartRecording();

            float prevPart = 0;
            float minDelta = 0.2f;

            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);

                float part = (float)writer.Position / maximumSize;
                int progressBarValue = (int)(part * RecordingProgressBar.Maximum);
                if (progressBarValue > RecordingProgressBar.Maximum)
                    progressBarValue = RecordingProgressBar.Maximum;

                void IncrementBar()
                {
                    RecordingProgressBar.Value = progressBarValue;
                }

                if (part - prevPart >= minDelta)
                {
                    RecordingProgressBar.BeginInvoke(new Action(IncrementBar));
                    prevPart = part;
                }

                if (writer.Position > maximumSize)
                {
                    waveIn.StopRecording();
                }
            };

            waveIn.RecordingStopped += (s, a) =>
            {
                writer?.Dispose();
                writer = null;
                PlaySampleButton.Enabled = true;
                RecordSampleButton.Enabled = true;
                waveIn.Dispose();
                RecordingProgressBar.Value = RecordingProgressBar.Maximum;
            };
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //byte[] _TEST_BUFFER = new byte[7800];
            _secSystem.SetVoiceSample(_userId, _sampleBuffer);
        }
    }
}
