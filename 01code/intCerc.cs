private int circInt(float cx0,
                    float cy0, 
                    float r0,
                     float cx1,
                     float cy1,
                     float r1,
                     out PointF i1,
                     out PointF i2)
{
    // Find the distance between the centers.
    float dx = cx0 - cx1;
    float dy = cy0 - cy1;
    double dist = Math.Sqrt(dx * dx + dy * dy);

    // See how many solutions there are.
    if (dist > r0 + r1)
    {
        // No solutions, the circles are too far apart.
        i1 = new PointF(float.NaN, float.NaN);
        i2 = new PointF(float.NaN, float.NaN);
        return 0;
    }
    else if (dist < Math.Abs(r0 - r1))
    {
        // No solutions, one circle contains the other.
        i1 = new PointF(float.NaN, float.NaN);
        i2 = new PointF(float.NaN, float.NaN);
        return 0;
    }
    else if ((dist == 0) && (r0 == r1))
    {
        // No solutions, the circles coincide.
        i1 = new PointF(float.NaN, float.NaN);
        i2 = new PointF(float.NaN, float.NaN);
        return 0;
    }
    else
    {
        // Find a and h.
        double a = (r0 * r0 - r1 * r1 + dist * dist) / (2 * dist);
        double h = Math.Sqrt(r0 * r0 - a * a);

        // Find P2.
        double cx2 = cx0 + a * (cx1 - cx0) / dist;
        double cy2 = cy0 + a * (cy1 - cy0) / dist;

        // Get the points P3.
        i1 = new PointF(
            (float)(cx2 + h * (cy1 - cy0) / dist),
            (float)(cy2 - h * (cx1 - cx0) / dist));
        i2 = new PointF(
            (float)(cx2 - h * (cy1 - cy0) / dist),
            (float)(cy2 + h * (cx1 - cx0) / dist));

        // See if we have 1 or 2 solutions.
        if (dist == r0 + r1) return 1;
        return 2;
    }
}