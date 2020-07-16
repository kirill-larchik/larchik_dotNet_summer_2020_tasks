namespace VectorClassLibrary
{
    /// <summary>
    /// Класс, описывающий трёхмерный вектор.
    /// </summary>
    public class TridimensionalVector
    {
        float x;
        float y;
        float z;

        /// <summary>
        /// Инициализирует новый экземпляр класса TridimensionalVector, который задается координатами вектора.
        /// </summary>
        /// <param name="x">Координата x.</param>
        /// <param name="y">Координата y.</param>
        /// <param name="z">Координата z.</param>
        public TridimensionalVector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Возвращает значение, показывающее, равен ли данный экземпляр заданному объекту.
        /// </summary>
        /// <param name="obj">Объект для сравнения с данным экземпляром.</param>
        /// <returns>Значение true, если параметр obj является экземпляром типа TridimensionalVector и равен
        /// значению данного экземпляра; в противном случае — значение false.</returns>
        public override bool Equals(object obj)
        {
            return obj is TridimensionalVector vector &&
                   x == vector.x &&
                   y == vector.y &&
                   z == vector.z;
        }

        /// <summary>
        /// Возвращает хэш-код данного экземпляра.
        /// </summary>
        /// <returns>Хэш-код в виде 32-разрядного целого числа со знаком.</returns>
        public override int GetHashCode()
        {
            int hashCode = 373119288;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Возвращает значение, указывающие, равны ли два заданные вектора.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Значение true, если left и right равны, иначе - значение false.</returns>
        public static bool operator ==(TridimensionalVector left, TridimensionalVector right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Возвращает значение, указывающие, не равны ли два заданные вектора.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Значение true, если left и right не равны, иначе - значение false.</returns>
        public static bool operator !=(TridimensionalVector left, TridimensionalVector right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Возвращает вектор - результат суммы двух заданных векторов.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Вектор - результат суммы двух заданных векторов.</returns>
        public static TridimensionalVector operator +(TridimensionalVector left, TridimensionalVector right)
        {
            return new TridimensionalVector(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        /// <summary>
        /// Возвращает вектор - результат вычитания двух заданных векторов.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Вектор - результат суммы вычитания заданных векторов.</returns>
        public static TridimensionalVector operator -(TridimensionalVector left, TridimensionalVector right)
        {
            return new TridimensionalVector(left.x - right.x, left.y - right.y, left.z - right.z);
        }

        /// <summary>
        /// Возвращает вектор - результат произведения заданного вектора на скаляр.
        /// </summary>
        /// <param name="vector">Вектор</param>
        /// <param name="scalar">Скаляр</param>
        /// <returns>Вектор - результат произведения заданного векторана скаляр</returns>
        public static TridimensionalVector operator *(TridimensionalVector vector, float scalar)
        {
            return new TridimensionalVector(vector.x * scalar, vector.y * scalar, vector.z * scalar);
        }

        /// <summary>
        /// Возвращает результат скалярного произведения двух заданных векторов.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Скалярное произведение</returns>
        public static float operator *(TridimensionalVector left, TridimensionalVector right)
        {
            return left.x * right.x + left.y * right.y + left.z * right.z;
        }
    }
}
