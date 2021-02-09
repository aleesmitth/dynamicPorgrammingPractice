namespace TestProject1 {
    public class Fibonacci {
        public static int Memoize(int i, int[] buffer){
            if (buffer[i] != 0) return buffer[i];
            else{
                buffer[i] = Memoize(i-1, buffer) + Memoize(i-2, buffer);
            }
            return buffer[i];
        }

        public static int BottomUp(int i, int n){
            int[] buffer = new int[n];
            buffer[0]=1;
            buffer[1]=1;
            for(int j=2; j<n; j++){
                buffer[j] = buffer[j-1]+buffer[j-2];
            }
            return buffer[i];
        }
    }
}