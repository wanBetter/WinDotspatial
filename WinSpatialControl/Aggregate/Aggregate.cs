using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSpatialControl.Aggregate
{
    class Aggregate
    {
    }
    /// <summary>
    /// 聚类矩阵异常信息
    /// </summary>
    public class MatrixExpection : Exception
    {
        public MatrixExpection()
        {

        }
        public MatrixExpection(string msg)
        {

        }
    }
    public class Clustering //使用最短距离聚类法进行聚类
    {
        public int n { get; set; }  //聚类的点的个数
        public BinaryTree br { get; set; }  //聚类使用的二叉树结构
        public int root { get; set; }    //当前聚类的根节点
        private double[,] matrix { get; set; }  //距离矩阵
        public int[] dirt { get; set; } //保存需要聚类的节点的字典
        public Clustering(int n, double[,] matrix)
        {
            this.n = n;
            this.root = n - 1;
            if (matrix.GetLength(1) != n || matrix.GetLength(0) != n)
            {
                throw new MatrixExpection("输入的距离矩阵与元素个数不匹配！");
            }
            else
            {
                dirt = new int[n];
                for (int i = 0; i < n; i++)
                {
                    dirt[i] = i;
                }
                this.matrix = new double[2 * n - 1, 2 * n - 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                       this.matrix[i, j] = matrix[i, j];
                    }
                }
            }
        }
        public void run()   //运行聚类方法，生成聚类二叉树
        {
            BinaryTree br = new BinaryTree();
            List<BinaryTree> brs = new List<BinaryTree>();
            for (int point = n; point > 1; point--)
            {
                int minX = 0;
                int minY = 0;
                double value = getMin(matrix, point, ref minX, ref minY); //获取距离矩阵中的最小值
                resetdirt(minX, minY, point);   //重新设置需要聚类的节点的字典
                setNewRoot(minX, minY, point);  //在距离矩阵中加入新的节点的距离
                br = new BinaryTree() { key = root, value = value };
                br.right = minX >= n ? brs.Find(i => i.key == minX) : new BinaryTree() { key = minX };  //判断当前节点的右节点是树节点还是叶子节点
                br.left = minY >= n ? brs.Find(i => i.key == minY) : new BinaryTree() { key = minY };
                brs.Add(br);
            }
            this.br = br;
        }
        public double getMin(double[,] matrix, int length, ref int x, ref int y)
        {
            double min = double.MaxValue;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (matrix[dirt[i], dirt[j]] < min && matrix[dirt[i], dirt[j]] != 0)
                    {
                        x = dirt[i]; y = dirt[j];
                        min = matrix[dirt[i], dirt[j]];
                    }
                }
            }
            return min;
        }
        public void resetdirt(int x, int y, int length)
        {
            for (int i = 0; i < length - 2; i++)
            {
                if (this.dirt[i] == x || this.dirt[i] == y)
                {
                    for (int j = i; j < length - 1; j++)
                    {
                        this.dirt[j] = this.dirt[j + 1];
                    }
                    if (i < length - 1) i--;
                }
            }
            this.dirt[length - 2] = ++this.root;
        }

        public void setNewRoot(int x, int y, int length)
        {
            for (int i = 0; i < length - 2; i++)
            {
                double ix = this.matrix[this.dirt[i], x];
                double iy = this.matrix[this.dirt[i], y];
                this.matrix[dirt[i], root] = ix < iy ? ix : iy;
                this.matrix[root, dirt[i]] = ix < iy ? ix : iy;
            }
        }
    }
    /// <summary>
    /// 聚类运算用到的二叉树结构
    /// 用于计算距离
    /// </summary>
    public class BinaryTree //二叉树结构
    {
        public int key;
        public double value;
        public BinaryTree right;
        public BinaryTree left;
        public int getDepth()
        { //获得二叉树实例的深度
            return getDepth(this);
        }
        private int getDepth(BinaryTree br)
        {
            if (br != null)
            {
                int rightdepth = getDepth(br.right);
                int leftdepth = getDepth(br.left);
                return (rightdepth > leftdepth ? rightdepth : leftdepth) + 1;
            }
            else
            {
                return 0;
            }
        }
        public void getCutBNList(BinaryTree bt, double cutValue, List<BinaryTree> BNList)
        {   //获取节点值小于规定值的树节点列表
            if (bt.value <= cutValue)
            {
                BNList.Add(bt);
            }
            else
            {
                getCutBNList(bt.left, cutValue, BNList);
                getCutBNList(bt.right, cutValue, BNList);
            }
        }
        public void getLeafList(BinaryTree bt, List<int> leafList)
        {    //获取树节点对应的叶子节点
            if (bt.left == null && bt.right == null)
            {
                leafList.Add(bt.key);
            }
            else
            {
                if (bt.left != null) getLeafList(bt.left, leafList);
                if (bt.right != null) getLeafList(bt.right, leafList);
            }
        }

        public List<List<int>> getCutLists(double cutValue)
        {   //获取分割后，每一个树节点对应的叶子节点 {树1:{叶子1, 叶子2, 叶子3}, 树2:{叶子1}}
            List<BinaryTree> BNList = new List<BinaryTree>();
            getCutBNList(this, cutValue, BNList);
            List<List<int>> cutLists = new List<List<int>>();
            foreach (BinaryTree bt in BNList)
            {
                List<int> cutList = new List<int>();
                getLeafList(bt, cutList);
                cutLists.Add(cutList);
            }
            return cutLists;
        }
        public string btToJson()    //将二叉树转化为json格式
        {
            return btToJson(this);
        }
        public string btToJson(BinaryTree bt)
        {
            string value = "value:" + bt.key;
            string right = "right:";
            string left = "left:";
            if (bt.right != null) { right += btToJson(bt.right); }
            if (bt.left != null) { left += btToJson(bt.left); }
            return "{" + value + "," + right + "," + left + "}";
        }
    }
}
