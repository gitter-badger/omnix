#!/bin/make
CC = gcc
CXX = g++
LDFLAGS = -lm

SRCS = Crc32_Castagnoli.cpp
OBJS := $(SRCS:.cpp=.o)

TARGET = Omnix_Cryptography.so

.PHONY: all clean
.SUFFIXES: .c .cpp .o

.c.o:
	$(CC) $(CFLAGS) -o $@ -c $^
.cpp.o:
	$(CXX) $(CXXFLAGS) -o $@ -c $^
.c:
	$(CC) $(CFLAGS) -o $@ $^ $(LDFLAGS)
.cpp:
	$(CXX) $(CXXFLAGS) -o $@ $^ $(LDFLAGS)

$(TARGET): $(OBJS)
	mkdir -p $(BUILD)
	$(CXX) $(CXXFLAGS) -o $(BUILD)/$(TARGET) $(OBJS)
	rm *.o

clean:
	rm -R $(BUILD)
	rm *.o
