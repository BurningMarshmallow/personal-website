docker build --no-cache -t personal-website .
docker run --rm -p 5000:80 personal-website
