# DrawingVisual相关api测试程序
本程序用于试验`DrawingVisual`的动态添加与删除
得出的结论:
1. 至少有两种方式可以添加DrawingVisual
方式1: 一般文档中介绍的`new VisualCollection(this)`
方式2: 直接用`AddVisualChild/AddLogicVisualChild`
决定使用方式2, 因为会用到逻辑对象(比如元件, 比如Pin), 方便HitTest

2. 这种方式可以用于作为局部刷新的工作机制

