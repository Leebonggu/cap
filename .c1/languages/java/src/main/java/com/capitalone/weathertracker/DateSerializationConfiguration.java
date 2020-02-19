package com.capitalone.weathertracker;

import com.fasterxml.jackson.databind.Module;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;
import com.fasterxml.jackson.datatype.jsr310.ser.ZonedDateTimeSerializer;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.convert.converter.Converter;
import org.springframework.stereotype.Component;

import java.time.ZonedDateTime;
import java.time.format.DateTimeFormatter;
import java.time.format.DateTimeFormatterBuilder;

@Configuration
class DateSerializationConfiguration {
  private final DateTimeFormatter dateTimeFormatter = new DateTimeFormatterBuilder()
    .parseCaseInsensitive()
    .appendInstant(3)
    .toFormatter();

  @Bean
  public DateTimeFormatter dateTimeFormatter() {
    return dateTimeFormatter;
  }

  @Bean
  public ObjectMapper objectMapper() {
    return new ObjectMapper()
      .registerModule(javaTimeModule())
      .disable(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS);
  }

  private Module javaTimeModule() {
    JavaTimeModule module = new JavaTimeModule();

    return module.addSerializer(ZonedDateTime.class, new ZonedDateTimeSerializer(dateTimeFormatter));
  }

  @Component
  static class ZonedDateTimeConverter implements Converter<String, ZonedDateTime> {
    @Override
    public ZonedDateTime convert(String source) {
      return ZonedDateTime.parse(source);
    }
  }
}
