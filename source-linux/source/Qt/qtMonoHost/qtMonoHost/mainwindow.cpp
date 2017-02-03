#include "mainwindow.h"
#include "ui_mainwindow.h"

static const MainWindow* m_selfReference;

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    m_monoWrapper = std::unique_ptr<monowrapper>(new monowrapper);
    m_selfReference = this;
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::LogMessage(const char *msg) {
    auto msgAsStr = std::string(msg);
    auto lstMessages = m_selfReference->findChild<QListWidget*>("lstMessages");
    new QListWidgetItem(tr(msgAsStr.c_str()), lstMessages);
}

void MainWindow::on_btnStartHost_clicked()
{
    std::function<void(const char*)> func =  &MainWindow::LogMessage;
    m_monoWrapper->CreateDomain(func);
}

void MainWindow::on_btnExitHost_clicked()
{
    m_monoWrapper->UnloadAppDomain();
    close();
}
