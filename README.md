# Batch-MLP-Encoder-3
"Batch MLP Encoder" is a software to help you with "WAV->MLP".<br>
MLP (Meridian Lossless Packing) is a lossless compression codec for audio data. It is mostly used in DVD-Audio. To make a MLP file, "Surcode MLP Encoder" is a must, bucause MLP is a closed proprietary format.<br>
However, "Surcode MLP Encoder" is not a friendly software. We wasted too much time on operating it: separate a multichannel WAV file into multiple mono WAV files, and then import these files into "Surcode MLP Encoder" one by one. It's boring and unbearable. (Yes, "Surcode MLP Encoder" do not support command-line, and we can only operate it through its unfriendly GUI.)<br>
We just want an easy way of "WAV->MLP", without the unnecessary manual work. "Batch MLP Encoder" is a software to automatically operate "Surcode MLP Encoder". All you need to do is drop your WAV files to "Batch MLP Encoder" and it will do the rest.<br>

## Environment Requirements
**Runtime**: .NET Framework 4.6 or later.<br>
**OS**: Windows Vista SP2/Windows 7 SP1/Windows 8/Windows 10 (It is incompatible with Windows XP.)<br>
**Software**: You need to install "Surcode MLP Encoder" and "eac3to".<br>

## License
GPL v2.0<br>

## How to Use
1. Download the latest binary program, and extract it. You can extract it to "Program files (x86)" folder or any  other folder you like.
2. Double-click "Batch-MLP-Encoder-3.exe" to run.
3. Select language "en-US", and click "OK".
4. In the "Welcome" tab, click "Browse" button to locate "Surcode MLP Encoder" and "eac3to". Then click "Next".
5. Drop your WAV files to the software or click "Add files" button. Then click "Next".
6. Select these options. Then click "Next".
7. click "Next" directly.
8. Click "Browse" button to set output folder and temporary folder. Then click "Start".
9. Wait until everything is done.
