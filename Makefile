build:
	docker build -t aspnetblazor .

run:
	docker run -it --rm -p 8080:80 --name aspnetblazorcontainer aspnetblazor