﻿using RayTracerLogic;

namespace RayTracerConsole
{
    /// <summary>
    /// Creates a sample scene for the example.
    /// </summary>
    public class TermPaperChapter07_06
    {
        /// <summary>
        /// Run this instance.
        /// </summary>
        public void Run()
        {
            System.Console.WriteLine("Example (term paper chapter 7.6)");

            World world = GetWorld();
            Camera camera = GetCamera();

            Canvas canvas = camera.Render(world);

            canvas.ToPpm("term-paper-chapter07-06.ppm");
            System.Console.WriteLine("    term-paper-chapter07-06.ppm successfully written.");
        }

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        public World GetWorld()
        {
            Sphere floor = new Sphere();
            floor.Transform = Matrix.NewScalingMatrix(10, 0.01, 10);
            floor.Material.Color = new Color(0.34, 0.1, 0.2);
            floor.Material.Specular = 0;

            Sphere leftWall = new Sphere();
            leftWall.Transform = Matrix.NewScalingMatrix(10, 0.01, 10)
                .RotateX(System.Math.PI / 2)
                .RotateY(-System.Math.PI / 4)
                .Translate(0, 0, 5);
            leftWall.Material.Color = new Color(1, 0.9, 0.9);
            leftWall.Material.Specular = 0;

            Sphere rightWall = new Sphere();
            rightWall.Transform = Matrix.NewScalingMatrix(10, 0.01, 10)
                .RotateX(System.Math.PI / 2)
                .RotateY(System.Math.PI / 4)
                .Translate(0, 0, 5);
            rightWall.Material.Color = new Color(1, 0.9, 0.9);
            rightWall.Material.Specular = 0;

            Sphere middle = new Sphere();
            middle.Transform = middle.Transform.Translate(-0.5, 1, 0.5);
            middle.Material.Color = new Color(1, 0.7, 0);

            Sphere right = new Sphere();
            right.Transform = right.Transform.Scale(0.5, 0.25, 0.25).RotateY(System.Math.PI * 0.33).Translate(1.5, 0.25, -0.5);
            right.Material.Color = new Color(0.5, 0, 0.5);
            right.Material.Diffuse = 0.7;
            right.Material.Specular = 0.3;

            Sphere left = new Sphere();
            left.Transform = left.Transform.Scale(0.5, 0.5, 0.5).Translate(-1.67, 0.5, -0.67);
            left.Material.Diffuse = 0.7;
            left.Material.Specular = 0.3;
            left.Material.Color = Color.GetWhite();

            World world = new World();
            world.LightSources.Add(new PointLight(new Point(-10, 10, -10), Color.GetWhite()));
            world.LightSources.Add(new PointLight(new Point(10, 5, 20), Color.GetWhite()));

            world.Shapes.Add(floor);
            world.Shapes.Add(leftWall);
            world.Shapes.Add(rightWall);
            world.Shapes.Add(middle);
            world.Shapes.Add(right);
            world.Shapes.Add(left);

            return world;
        }

        /// <summary>
        /// Gets the camera.
        /// </summary>
        /// <returns>The camera.</returns>
        public Camera GetCamera()
        {
            Camera camera = new Camera(1080, 720, System.Math.PI / 3);

            camera.Transform = new Point(0, 1.5, -5).ViewTransform(new Point(0, 1, 0), new Vector(0, 1, 0));

            return camera;
        }
    }
}
