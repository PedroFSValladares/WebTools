namespace WebTools.Utilities {
    public static class Math {
        public static float Normalize(float x, float min, float max) {
            return (x - min) / (max - min);
        }
    }
}
