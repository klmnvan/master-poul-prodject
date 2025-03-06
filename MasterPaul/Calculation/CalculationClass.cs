namespace Calculation
{
    public class CalculationClass
    {
        public List<(int IdType, double PercentMarriage)> _materialTypes = new()
        {
            (1,0.1),
            (2,0.95),
            (3,0.28),
            (4,0.55),
            (5,0.34),
        };

        public List<(int IdType, double Ratio)> _productTypes = new()
        {
           ( 1, 2.35),
           ( 2, 5.15),
           ( 3, 4.34),
           ( 4, 1.5),
        };

        //Конструктор для вычислений по значениям типов, известных на момент создания библиотеки (и для тестирования)
        public CalculationClass() { }

        public int GetQuantityForProduct(int typeProduct, int typeMaterial, int quantityProduct, double weight, double height)
        {
            int quantityMaterial = 0;
            double percent_marriage = 0, ratio = 0;
            //проверка на исключительные ситуации
            if (!_materialTypes.Any(it => it.IdType == typeMaterial) || !_productTypes.Any(it => it.IdType == typeProduct) 
                || quantityProduct < 0 || weight < 0 || height < 0) return -1;
            percent_marriage = (_materialTypes.First(it => it.IdType == typeMaterial).PercentMarriage);
            ratio = (_productTypes.First(it => it.IdType == typeProduct).Ratio);
            int quantityFor1Product = (int)((weight * height) * (double)ratio);
            //количество материала для изготовления 1 продукции * количество необходимой продукции * (1 + процент брака)
            quantityMaterial = (int)(quantityFor1Product * quantityProduct * (1.0 + (double)percent_marriage));
            return quantityMaterial;
        }
    }
}
