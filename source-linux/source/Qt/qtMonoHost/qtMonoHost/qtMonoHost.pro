#-------------------------------------------------
#
# Project created by QtCreator 2016-06-03T22:02:55
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = qtMonoHost
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
        monowrapper.cpp

HEADERS  += mainwindow.h \
            monowrapper.h

FORMS    += mainwindow.ui

INCLUDEPATH += /usr/include/mono-2.0 \

LIBS += -lrt \
        -ldl \
        /usr/lib/libmono-2.0.so \
        /usr/lib/libmonosgen-2.0.so.1

QMAKE_CXXFLAGS += `pkg-config --cflags --libs mono-2` -Wall

QMAKE_LFLAGS += `pkg-config --libs mono-2`

CONFIG += C++11
