# conding:utf-8

from django.shortcuts import render
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status

# Create your views here.

@api_view(['GET'])
def hello(request):
    result = 'Python Web Host Application Starup Success.'
    return Response(result, status=status.HTTP_200_OK)