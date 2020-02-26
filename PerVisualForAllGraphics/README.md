# DrawingVisual相关api测试程序
每条线使用一个`DrawingVisual`

## 测试结果
### Individual
每条线使用一个`DrawingVisual`
使用 `VisualCollection`
需要7秒

### Individual2
同上, 但使用`AddVisualChild & AddLogicalChild`
需要7秒

### InOneGroup
同上, 但是全部放到一个DrawingGroup中, 最后统一drawDrawing(group)
没有想到的是: 最慢, 近30秒


