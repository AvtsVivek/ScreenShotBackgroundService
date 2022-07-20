using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScreenShot.Domain;

namespace ScreenShot.Wpf;

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
public partial class MainWindow : Window
{
  private BackgroundWorker _backgroundWorker = new BackgroundWorker();
  private IPrintScreenService _printScreenService;

  public MainWindow()
  {
    this.ShowInTaskbar = false;
    
    _printScreenService = new PrintScreenService();
    InitializeComponent();
    AdditionalInitialization();
    StartCapture();
  }

  private void Button_Click(object sender, RoutedEventArgs e)
  {
    StartCapture();
  }

  public void StartCapture()
  {
    try
    {
      //var arg1 = short.Parse(textBoxArg1.Text);
      //var arg2 = short.Parse(textBoxArg2.Text);

      //var args = new WorkerParam(arg1, arg2);

      var args = new WorkerParam();

      _backgroundWorker.RunWorkerAsync(args);

      // button.IsEnabled = false;

    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message);
    }
  }

  private void worker_do_work(object sender, DoWorkEventArgs e)
  {
    //var param = (WorkerParam)e.Argument;
    // _printScreenService.CaptureScreenEvery(param.arg1);

    _printScreenService.CaptureScreenEvery(10);

    // make this thread sleep 5 seconds
    // Thread.Sleep(5000);

    // e.Result = param.arg1 + param.arg2;
  }

  private void worker_completed(object sender, RunWorkerCompletedEventArgs e)
  {
    MessageBox.Show(e.Result.ToString(), "Computed Result");
    button.IsEnabled = true;
  }
  void AdditionalInitialization()
  {
    _backgroundWorker.DoWork +=
        new DoWorkEventHandler(worker_do_work);

    _backgroundWorker.RunWorkerCompleted +=
        new RunWorkerCompletedEventHandler(worker_completed);

    
  }
}

class WorkerParam
{
  public short arg1, arg2;
  public WorkerParam()
  {

  }
  public WorkerParam(short a, short b)
  {
    arg1 = a; arg2 = b;
  }
}
