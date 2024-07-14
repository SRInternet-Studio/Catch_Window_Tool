Imports System.Runtime.InteropServices
Imports System.Text

Class MainWindow
    Dim tname1
    Dim leitext1
    Dim HWNDText1
    Dim showtext1
    Dim cuntext1
    Dim leixintext1

    Private Const GWL_EXSTYLE As Integer = -20

    Const WS_EX_DLGMODALFRAME As Integer = &H1
    Const WS_EX_NOPARENTNOTIFY As Integer = &H4
    Const WS_EX_TOPMOST As Integer = &H8
    Const WS_EX_ACCEPTFILES As Integer = &H10
    Const WS_EX_TRANSPARENT As Integer = &H20
    Const WS_EX_MDICHILD As Integer = &H40
    Const WS_EX_TOOLWINDOW As Integer = &H80
    Const WS_EX_WINDOWEDGE As Integer = &H100
    Const WS_EX_CLIENTEDGE As Integer = &H200
    Const WS_EX_CONTEXTHELP As Integer = &H400
    Const WS_EX_RIGHT As Integer = &H1000
    Const WS_EX_LEFT As Integer = &H0
    Const WS_EX_RTLREADING As Integer = &H2000
    Const WS_EX_LTRREADING As Integer = &H0
    Const WS_EX_LEFTSCROLLBAR As Integer = &H4000
    Const WS_EX_RIGHTSCROLLBAR As Integer = &H0
    Const WS_EX_CONTROLPARENT As Integer = &H10000
    Const WS_EX_STATICEDGE As Integer = &H20000
    Const WS_EX_APPWINDOW As Integer = &H40000
    Const WS_EX_OVERLAPPEDWINDOW As Integer = (WS_EX_WINDOWEDGE Or WS_EX_CLIENTEDGE)
    Const WS_EX_PALETTEWINDOW As Integer = (WS_EX_WINDOWEDGE Or WS_EX_TOOLWINDOW Or WS_EX_TOPMOST)
    Const WS_EX_LAYERED As Integer = &H80000
    Const WS_EX_NOINHERITLAYOUT As Integer = &H100000
    Const WS_EX_NOREDIRECTIONBITMAP As Integer = &H200000
    Const WS_EX_LAYOUTRTL As Integer = &H400000
    Const WS_EX_COMPOSITED As Integer = &H2000000
    Const WS_EX_NOACTIVATE As Integer = &H8000000

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function GetWindowText(ByVal hwnd As IntPtr, ByVal lpString As StringBuilder, ByVal cch As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function GetClassName(ByVal hWnd As IntPtr, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure WINDOWPLACEMENT
        Public Length As Integer
        Public flags As Integer
        Public showCmd As Integer
        Public ptMinPosition As Point
        Public ptMaxPosition As Point
        Public rcNormalPosition As Rect
    End Structure

    <DllImport("user32.dll")>
    Private Shared Function GetWindowPlacement(ByVal hWnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    Public Shared Function GetWindowDimensions(ByVal hWnd As IntPtr) As RECT
        Dim placement As New WINDOWPLACEMENT()
        placement.Length = Marshal.SizeOf(placement)
        GetWindowPlacement(hWnd, placement)
        Return placement.rcNormalPosition
    End Function

    Private Sub Top_Click(sender As Object, e As RoutedEventArgs) Handles ATop.Checked
        Me.Topmost = True
    End Sub
    Private Sub Top_Not_Click(sender As Object, e As RoutedEventArgs) Handles ATop.Unchecked
        Me.Topmost = False
    End Sub

    Private Sub Exit_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        MsgBox($"名称：抓取窗口工具 Catch_Window_Tool{vbCrLf}制作出品：思锐工作室{vbCrLf}QQ群：367798007{vbCrLf}Bilibili：SR思锐Official", vbInformation)
    End Sub

    Function Catch_window()

        Dim foregroundH As IntPtr = GetForegroundWindow()
        Dim foregroundHandle = foregroundH
        If foregroundH.ToString <> HWNDText1 Then
            Dispatcher.BeginInvoke(Sub() HWNDText.Text = foregroundH.ToString)
        End If

        Dim windowTitle As New StringBuilder(256)
        GetWindowText(foregroundHandle, windowTitle, windowTitle.Capacity)

        If windowTitle.ToString <> tname1 Then
            Dispatcher.BeginInvoke(Sub() tname.Text = windowTitle.ToString)
        End If

        Dim className As New StringBuilder(256)
        GetClassName(foregroundHandle, className, className.Capacity)

        If className.ToString <> leitext1 Then
            Dispatcher.BeginInvoke(Sub() leitext.Text = className.ToString)
        End If

        Dim localCmd As String
        Dim placementwidth = Nothing
        Dim placementheight = Nothing
        Dim placement As WINDOWPLACEMENT = New WINDOWPLACEMENT()
        placement.Length = Marshal.SizeOf(placement)
        If GetWindowPlacement(foregroundHandle, placement) Then
            Select Case placement.showCmd
                Case 0
                    localCmd = "0 (SW_HIDE 窗口已隐藏)"
                Case 1
                    localCmd = "1 (SW_SHOWNORMAL 正常窗口)"
                Case 2
                    localCmd = "2 (SW_SHOWMINIMIZED 最小化窗口)"
                Case 3
                    localCmd = "3 (SW_SHOWMAXIMIZED 最大化窗口)"
                Case 4
                    localCmd = "4 (SW_SHOWNOACTIVATE 窗口未激活)"
                Case 5
                    localCmd = "5 (SW_SHOW 窗口已显示)"
                Case 6
                    localCmd = "6 (SW_MINIMIZE 窗口已最小化)"
                Case 7
                    localCmd = "7 (SW_SHOWMINNOACTIVE 最小化未激活)"
                Case 8
                    localCmd = "8 (SW_SHOWNA 窗口未定义)"
                Case 9
                    localCmd = "9 (SW_RESTORE 窗口已恢复)"
                Case 10
                    localCmd = "10 (SW_SHOWDEFAULT 窗口)"
                Case 11
                    localCmd = "11 (SW_FORCEMINIMIZE 窗口已挂起)"
                Case Else
                    localCmd = placement.showCmd.ToString
            End Select
        Else
            localCmd = "None"
        End If

        If localCmd <> showtext1 Then
            Dispatcher.BeginInvoke(Sub() showtext.Text = localCmd)
        End If

        Dim rect As RECT = GetWindowDimensions(foregroundH)
        Dim width As Integer = rect.Right - rect.Left
        Dim height As Integer = rect.Bottom - rect.Top
        Dim W_H = $"{width} x {height}"

        If W_H <> cuntext1 Then
            Dispatcher.BeginInvoke(Sub() cuntext.Text = W_H)
        End If

        Dim style_name = GetWindowExStyle(foregroundH)
        If style_name <> leixintext1 Then
            Dispatcher.BeginInvoke(Sub() leixintext.Text = style_name)
        End If

    End Function

    Private Async Sub Main()
        While True
            tname1 = tname.Text
            leitext1 = leitext.Text
            HWNDText1 = HWNDText.Text
            showtext1 = showtext.Text
            cuntext1 = cuntext.Text
            leixintext1 = leixintext.Text
            Await Task.Delay(10)
            Await Task.Run(AddressOf Catch_window)
        End While
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Main()
    End Sub

    Public Shared Function GetWindowExStyle(ByVal hWnd As IntPtr) As String
        Dim exStyle As Integer = GetWindowLong(hWnd, GWL_EXSTYLE)

        Dim styles As New List(Of String)

        If (exStyle And WS_EX_DLGMODALFRAME) <> 0 Then styles.Add("DLGMODALFRAME")
        If (exStyle And WS_EX_NOPARENTNOTIFY) <> 0 Then styles.Add("NOPARENTNOTIFY")
        If (exStyle And WS_EX_TOPMOST) <> 0 Then styles.Add("TOPMOST")
        If (exStyle And WS_EX_ACCEPTFILES) <> 0 Then styles.Add("ACCEPTFILES")
        If (exStyle And WS_EX_TRANSPARENT) <> 0 Then styles.Add("TRANSPARENT")
        If (exStyle And WS_EX_MDICHILD) <> 0 Then styles.Add("MDICHILD")
        If (exStyle And WS_EX_TOOLWINDOW) <> 0 Then styles.Add("TOOLWINDOW")
        If (exStyle And WS_EX_WINDOWEDGE) <> 0 Then styles.Add("WINDOWEDGE")
        If (exStyle And WS_EX_CLIENTEDGE) <> 0 Then styles.Add("CLIENTEDGE")
        If (exStyle And WS_EX_CONTEXTHELP) <> 0 Then styles.Add("CONTEXTHELP")
        If (exStyle And WS_EX_RIGHT) <> 0 Then styles.Add("RIGHT")
        If (exStyle And WS_EX_RTLREADING) <> 0 Then styles.Add("RTLREADING")
        If (exStyle And WS_EX_LEFTSCROLLBAR) <> 0 Then styles.Add("LEFTSCROLLBAR")
        If (exStyle And WS_EX_CONTROLPARENT) <> 0 Then styles.Add("CONTROLPARENT")
        If (exStyle And WS_EX_STATICEDGE) <> 0 Then styles.Add("STATICEDGE")
        If (exStyle And WS_EX_APPWINDOW) <> 0 Then styles.Add("APPWINDOW")
        If (exStyle And WS_EX_OVERLAPPEDWINDOW) <> 0 Then styles.Add("OVERLAPPEDWINDOW")
        If (exStyle And WS_EX_PALETTEWINDOW) <> 0 Then styles.Add("PALETTEWINDOW")
        If (exStyle And WS_EX_LAYERED) <> 0 Then styles.Add("LAYERED")
        If (exStyle And WS_EX_NOINHERITLAYOUT) <> 0 Then styles.Add("NOINHERITLAYOUT")
        If (exStyle And WS_EX_NOREDIRECTIONBITMAP) <> 0 Then styles.Add("NOREDIRECTIONBITMAP")
        If (exStyle And WS_EX_LAYOUTRTL) <> 0 Then styles.Add("LAYOUTRTL")
        If (exStyle And WS_EX_COMPOSITED) <> 0 Then styles.Add("COMPOSITED")
        If (exStyle And WS_EX_NOACTIVATE) <> 0 Then styles.Add("NOACTIVATE")

        If styles.Count = 0 Then
            Return "无扩展样式"
        Else
            Return String.Join(", ", styles)
        End If
    End Function

    Private Sub Help_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Help.MouseLeftButtonDown
        Dim message = "WS_EX_DLGMODALFRAME (0x00000001): 创建一个带有双边框的窗口，主要用于对话框。
WS_EX_NOPARENTNOTIFY (0x00000004): 子窗口创建时不通知父窗口。
WS_EX_TOPMOST (0x00000008): 窗口总是位于顶层。
WS_EX_ACCEPTFILES (0x00000010): 窗口接受拖放的文件。
WS_EX_TRANSPARENT (0x00000020): 窗口下面的所有窗口在该窗口绘制之前绘制。
WS_EX_MDICHILD (0x00000040): 创建一个多文档界面（MDI）子窗口。
WS_EX_TOOLWINDOW (0x00000080): 创建一个工具窗口，它是一个未显示在任务栏中的窗口。
WS_EX_WINDOWEDGE (0x00000100): 窗口具有带边缘的三维边框。
WS_EX_CLIENTEDGE (0x00000200): 窗口具有带边缘的三维边框，用于表示客户端区域。
WS_EX_CONTEXTHELP (0x00000400): 窗口具有"“?”"按钮。
WS_EX_RIGHT (0x00001000): 窗口具有右对齐属性。
WS_EX_LEFT (0x00000000): 窗口具有左对齐属性（默认）。
WS_EX_RTLREADING (0x00002000): 窗口文本从右到左读。
WS_EX_LTRREADING (0x00000000): 窗口文本从左到右读（默认）。
WS_EX_LEFTSCROLLBAR (0x00004000): 窗口的滚动条位于左侧。
WS_EX_RIGHTSCROLLBAR (0x00000000): 窗口的滚动条位于右侧（默认）。
WS_EX_CONTROLPARENT (0x00010000): 窗口可包含子控件。
WS_EX_STATICEDGE (0x00020000): 窗口具有静态边框。
WS_EX_APPWINDOW (0x00040000): 窗口显示在任务栏上。
WS_EX_OVERLAPPEDWINDOW (WS_EX_WINDOWEDGE Or WS_EX_CLIENTEDGE): 窗口具有重叠窗口的样式。
WS_EX_PALETTEWINDOW (WS_EX_WINDOWEDGE Or WS_EX_TOOLWINDOW Or WS_EX_TOPMOST): 窗口具有调色板窗口的样式。
WS_EX_LAYERED (0x00080000): 窗口具有分层样式。
WS_EX_NOINHERITLAYOUT (0x00100000): 子窗口不继承布局。
WS_EX_NOREDIRECTIONBITMAP (0x00200000): 窗口不使用红irection位图。
WS_EX_LAYOUTRTL (0x00400000): 窗口布局为从右到左。
WS_EX_COMPOSITED (0x02000000): 窗口使用复合样式。
WS_EX_NOACTIVATE (0x08000000): 窗口不能被激活。"
        MsgBox(message, vbInformation, "抓取窗口工具 - 类型解析")
    End Sub
End Class
