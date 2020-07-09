using System;
using OpenTK.Graphics.OpenGL;

class WaveformGraphState : IGameObject {
    double _xPosition = -100;
    double _yPosition = -100;
    double _xLength = 200;
    double _yLength = 200;
    double _sampleSize = 100;
    double _frequency = 2;
    public delegate double WaveFunction(double value);

    public WaveformGraphState() {
        GL.LineWidth(3);
        GL.Disable(EnableCap.Texture2D);
    }

    public void DrawAxis(Color color) {
        GL.Color3(color.Red, color.Green, color.Blue);
        GL.Begin(PrimitiveType.Lines); {
            // X axis
            GL.Vertex2(_xPosition, _yPosition);
            GL.Vertex2(_xPosition + _xLength, _yPosition);
            // Y axis
            GL.Vertex2(_xPosition, _yPosition);
            GL.Vertex2(_xPosition, _yPosition + _yLength);
        }
        GL.End();
    }

    public void DrawGraph(WaveFunction waveFunction, Color color) {
        double xIncrement = _xLength / _sampleSize;
        double previousX = _xPosition;
        double previousY = _yPosition + (0.5 * _yLength);
        GL.Color3(color.Red, color.Green, color.Blue);
        GL.Begin(PrimitiveType.Lines); {
            for (int i = 0; i < _sampleSize; i++) {
                // work out new x and y positions
                double newX = previousX + xIncrement; // Increment one unit on the x
                // from 0-1 how far through the plotting the graph are we?
                double percentDone = (i / _sampleSize);
                double percentRadians = percentDone * (Math.PI * _frequency);

                // Scale the wave value by half o fthe length
                double newY = _yPosition + waveFunction(percentRadians) * (_yLength / 2);
                
                // Ignore the first value because the previous X and Y haven't been worked out yet
                if (i > 1) {
                    GL.Vertex2(previousX, previousY);
                    GL.Vertex2(newX, newY);
                }

                // Store previous positions
                previousX = newX;
                previousY = newY;
            }
        }
        GL.End();
    }

    public void Update(double deltaTime)
    {
        // throw new System.NotImplementedException();
    }

    public void Render()
    {
        DrawAxis(new Color(1,1,1,1));

        // DrawGraph(Math.Sin, new Color(1,0,0,1));
        // DrawGraph(Math.Cos, new Color(0,0.5f,0.5f,1));
        
        DrawGraph(delegate (double value) {
            return (Math.Sin(value) + Math.Cos(value)) * 0.5;
        }, new Color(0.5f, 0.5f, 1, 1));

        DrawGraph(delegate (double value) {
            return (Math.Sin(value) + Math.Cos(value + value)) * 0.5;
        }, new Color(0.5f, 0.5f, 1, 1));
    }
}